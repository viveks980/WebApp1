using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class LoginClass : LoginInterface
    {
        string Connection = "Data Source=DESKTOP-DNP394E\\SQLEXPRESS;Initial Catalog=coreDemo;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;";


        public loginmodel Login([FromForm] loginmodel login)
        {
            loginmodel res = new loginmodel();
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(login.password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey,new byte[] { 0x49,0x76,0x61,0x6e,0x20,0x4d,0x65,0x64,0x76,0x65,0x64,0x65,0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    res.password = Convert.ToBase64String(ms.ToArray());
                    res.userName = login.userName;
                }
                //addstudent(res.userName,res.password)
            }
            return res;
        }

        public loginmodel  adduser(loginmodel objmodel)
        {
            loginmodel res = new loginmodel();

            using (SqlConnection con = new SqlConnection(Connection))
            {  
                try
                {
                    con.Open();

                    using (SqlCommand checkUsernameCmd = new SqlCommand("SELECT COUNT(*) FROM user_table WHERE name = @userName", con))

                    {
                        checkUsernameCmd.Parameters.AddWithValue("@userName", objmodel.userName);
                        int existingUserCount = (int)checkUsernameCmd.ExecuteScalar();

                        if (existingUserCount > 0)
                        {
                            res.status = false;
                            res.Message = "User Already exists. Please Login...!!";
                        }
                        else
                        {

                            using (SqlCommand cmd = new SqlCommand("saveuser", con))
                            {

                                string EncryptionKey = "MAKV2SPBNI99212";
                                byte[] clearBytes = Encoding.Unicode.GetBytes(objmodel.password);
                                using (Aes encryptor = Aes.Create())
                                {
                                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                                    encryptor.Key = pdb.GetBytes(32);
                                    encryptor.IV = pdb.GetBytes(16);
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                                        {
                                            cs.Write(clearBytes, 0, clearBytes.Length);
                                            cs.Close();
                                        }
                                        res.password = Convert.ToBase64String(ms.ToArray());
                                        res.userName = objmodel.userName;
                                        res.Decryped_password = objmodel.password;
                                    }

                                }



                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@name", res.userName);
                                cmd.Parameters.AddWithValue("@password", res.password);
                                cmd.Parameters.AddWithValue("@status", objmodel.status);
                                var id = cmd.ExecuteNonQuery();





                                if (id > 0)
                                {
                                    res.status = true;
                                    res.Message = "Data Saved Successfully";
                                    res.Id = id;


                                }
                                else
                                {
                                    res.status = false;
                                    res.Message = "Please Check...Something Went wrong...!!!";

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.status = false;
                    Helper.WriteLog("The error is:" + ex);
                    Console.WriteLine("Error is:" + ex);
                   

                }
                finally
                {
                    con.Close();
                    con.Dispose();

                }
            }
            return res;

        }


        public List<loginmodel> getuserbyid(int Id)   

        {
           loginmodel resm = new loginmodel();

            List<loginmodel> res = new List<loginmodel>();

            using (SqlConnection con = new SqlConnection(Connection))

            {

                con.Open();

                try

                {
                    // code for Demo on error log
                   // int[] myNumbers = { 1, 2, 3 };
                   // Console.WriteLine(myNumbers[10]);


                    using (SqlCommand cmd = new SqlCommand("getuserbyid", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);

                        var id = cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)

                        {

                            while (reader.Read())

                            {

                                loginmodel u = new loginmodel();
                                u.Id = (int)reader["id"];

                                u.userName = (string)reader["name"];

                                u.password = (string)reader["password"];


                                u.status = (bool)reader["status"];





                                string encryptedPassword = u.password;
                                string EncryptionKey = "MAKV2SPBNI99212";
                                byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

                                using (Aes decryptor = Aes.Create())
                                {
                                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                                    decryptor.Key = pdb.GetBytes(32);
                                    decryptor.IV = pdb.GetBytes(16);

                                    using (MemoryStream ms = new MemoryStream(encryptedBytes))
                                    {
                                        using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Read))
                                        {
                                            using (StreamReader reader1 = new StreamReader(cs, Encoding.Unicode))
                                            {
                                                string decryptedPassword = reader1.ReadToEnd();
                                                
                                                u.Decryped_password = decryptedPassword;
                                            }
                                        }
                                    }
                                }




                                res.Add(u);





                            }

                        }


                    }
                }

                catch (Exception ex)

                {

                    Helper.WriteLog("The error is:" + ex);
                    Console.WriteLine("Error is:" + ex);
                    //Helper.WriteLog("The error is:" + ex);

                }

                finally

                {

                    con.Close();

                    con.Dispose();

                }

                return res;

            }



        }

    }
}
