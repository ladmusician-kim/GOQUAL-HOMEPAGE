using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GOQUAL.Service
{
    public class MailService
    {
        public const int SendTryLimit = 5;
        public static void SendAsync(string email, string title, string body)
        {
            for (int trycount = 0; trycount < SendTryLimit; trycount++)
            {
                try
                {
                    using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                    {
                        client.Credentials = new NetworkCredential("ladmusician.kgj@gmail.com", "1726836rja");
                        client.EnableSsl = true;

                        MailAddress from = new MailAddress("ladmusician.kgj@gmail.com", "ladmusician.kgj@gmail.com", System.Text.Encoding.UTF8);
                        MailAddress to = new MailAddress(email);

                        using (MailMessage message = new MailMessage(from, to))
                        {
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.SubjectEncoding = System.Text.Encoding.UTF8;
                            message.Subject = title; //title
                            message.IsBodyHtml = true;
                            message.Body = body; //body
                            message.Body += Environment.NewLine;

                            client.Send(message);
                        }
                        break;
                    }
                }
                catch (Exception e)
                {
                    Thread.Sleep(3000);
                }
            }
        }
    }
}