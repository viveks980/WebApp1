using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class EmailClass : Interface
    {
      
  public ResponseModel StaticMailSend()

        {

            ResponseModel res = new ResponseModel();

            MailMessage msg = new MailMessage();

            SmtpClient smtp = new SmtpClient();

            msg.From = new MailAddress("vivek.swami@cylsys.com");

            msg.To.Add("anshu.khare@cylsys.com");
            msg.To.Add("anisha.singh@cylsys.com");



            msg.Subject = "Testing Mail";

            msg.Body = "This is tesing mail from .net core";

            msg.IsBodyHtml = true;

            smtp.Host = "smtp-mail.outlook.com";

            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("vivek.swami@cylsys.com", "Cylsys@2");

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(msg);

            res.Message = "MailSent!!!";

            return res;

        }

       
  public ResponseModel StaticMailSendTemp(String name, string EmpId, string dob, String mbl)

        {

            ResponseModel res = new ResponseModel();

            string templatePath = @"C:\Users\vivek\source\repos\WebApplication1\EmailTemplate\EmailTemp.html";

            string emailBody;

            

            using (StreamReader reader = new StreamReader(templatePath))

            {

                emailBody = reader.ReadToEnd();

            }

            

            emailBody = emailBody.Replace("{name}", name);
            emailBody = emailBody.Replace("{EmpId}", EmpId);

            emailBody = emailBody.Replace("{dob}", dob);

            
            emailBody = emailBody.Replace("{mbl}", mbl);

            MailMessage msg = new MailMessage();

            SmtpClient smtp = new SmtpClient();

            msg.From = new MailAddress("vivek.swami@cylsys.com");

            msg.To.Add("anil.patel@cylsys.com");

            msg.Subject = "Testing Mail for email_Template";

            

            msg.Body = emailBody;

            msg.IsBodyHtml = true;

            smtp.Host = "smtp-mail.outlook.com";

            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("vivek.swami@cylsys.com", "Cylsys@2");

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(msg);

            res.Message = "MailSent!!!";

            return res;

        }

       

       

       
    }
    }


