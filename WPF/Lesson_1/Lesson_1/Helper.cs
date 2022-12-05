using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    public class Helper
    {
        public static string SendMsg(string to, string subject, string body, out bool result)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("nurkworld534@gmail.com", "Seysenbay Nurzhan");
            msg.To.Add(to);
            //msg.CC.Add("");
            msg.Subject = subject;
            msg.Priority = MailPriority.High;
            msg.Body = body;
            //msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-relay.gmail.com";
            smtp.Port = 587;
            //smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("login", "password");
            try
            {
                smtp.Send(msg);
                result = true;
                return "Сообщение отправлено";
            }
            catch (Exception ex)
            {
                result = false;
                return ex.Message;
            }
        }
    }
}
