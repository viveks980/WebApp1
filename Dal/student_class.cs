using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Dal
{
    public class student_class
    {
        string Connection = "Data Source=DESKTOP-DNP394E\\SQLEXPRESS;Initial Catalog=coreDemo;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;";
        public ResponseModel addstudent(user objmodel) {
            ResponseModel result = new ResponseModel();

            using (SqlConnection con = new SqlConnection(Connection)) 
            {   
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("savename", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@name", objmodel.Name);
                        cmd.Parameters.AddWithValue("@department", objmodel.department);
                        cmd.Parameters.AddWithValue("@joindate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@status", objmodel.status);
                        cmd.Parameters.AddWithValue("@rollno", objmodel.rollno);
                        var id = cmd.ExecuteNonQuery();
                        
                        if (id > 0)
                        {
                            result.status = true;
                            result.Message = "Data Saved Successfully";
                            result.Id = id;


                        }
                        else
                        {
                            result.status = false;
                            result.Message = "Please Check...Something Went wrong...!!!";

                        }
                    }

                }
                catch (Exception ex)
                {
                    result.status = false;
                    result.Message = "Exception Occure..!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();

                }
            }
            return result;
        
        }
        public ResponseModel updatestudent(user objmodel)
        {
            ResponseModel result = new ResponseModel();

            using (SqlConnection con = new SqlConnection(Connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("updatestudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", objmodel.Id);
                        cmd.Parameters.AddWithValue("@name", objmodel.Name);
                        cmd.Parameters.AddWithValue("@department", objmodel.department);
                        cmd.Parameters.AddWithValue("@joindate", DateTime.UtcNow);
                        cmd.Parameters.AddWithValue("@status", objmodel.status);
                        cmd.Parameters.AddWithValue("@rollno", objmodel.rollno);
                        var Id = cmd.ExecuteNonQuery();

                        if (Id > 0)
                        {
                            result.status = true;
                            result.Message = "Data Updated Successfully..!!";
                            result.Id = Id;


                        }
                        else
                        {
                            result.status = false;
                            result.Message = "Please Check...Something Went wrong...!!!";

                        }
                    }

                }
                catch (Exception ex)
                {
                    result.status = false;
                    result.Message = "Exception Occure..!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();

                }
            }
            return result;

        }

        public ResponseModel deletestudent(int Id)

        {
            ResponseModel result = new ResponseModel();

            using (SqlConnection con = new SqlConnection(Connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("deletestudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id",Id);
                        
                        var id = cmd.ExecuteNonQuery();

                        if (id > 0)
                        {
                            result.status = true;
                            result.Message = "Data Deleted Successfully..!!";
                            result.Id = Id;


                        }
                        else
                        {
                            result.status = false;
                            result.Message = "Please Check...Something Went wrong...!!!";

                        }
                    }

                }
                catch (Exception ex)
                {
                    result.status = false;
                    result.Message = "Exception Occure..!!";

                }
                finally
                {
                    con.Close();
                    con.Dispose();

                }
            }
            return result;

        }
        public List<user> getstudentdetails()

        {

            List<user> res = new List<user>();

            using (SqlConnection con = new SqlConnection(Connection))

            {

                con.Open();

                try

                {

                    using (SqlCommand cmd = new SqlCommand("select * from student_table", con))

                    {

                        cmd.CommandType = CommandType.Text;

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)

                        {

                            while (reader.Read())

                            {

                                user u = new user();
                                u.Id = (int)reader["id"];

                                u.Name = (string)reader["name"];

                                u.department = (string)reader["department"];

                                u.joindate = (DateTime)reader["joindate"];

                                u.status = (bool)reader["status"];

                                u.rollno = (int)reader["rollno"];

                                res.Add(u);



                            }

                        }

                    }

                }

                catch (Exception ex)

                {

                    Console.WriteLine(ex);

                }

                finally

                {

                    con.Close();

                    con.Dispose();

                }

                return res;

            }



        }

        public List<user> getstudentbyid(int Id)

        {
            ResponseModel resm = new ResponseModel();

            List<user> res = new List<user>();

            using (SqlConnection con = new SqlConnection(Connection))

            {

                con.Open();

                try

                {
                    using (SqlCommand cmd = new SqlCommand("getstudentbyid", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);

                        var id = cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)

                        {

                            while (reader.Read())

                            {

                                user u = new user();
                                u.Id = (int)reader["id"];

                                u.Name = (string)reader["name"];

                                u.department = (string)reader["department"];

                                u.joindate = (DateTime)reader["joindate"];

                                u.status = (bool)reader["status"];

                                u.rollno = (int)reader["rollno"];

                                res.Add(u);



                            }

                        }


                    }
                }

                catch (Exception ex)

                {

                    Console.WriteLine(ex);

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
