using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace MailApp.UserClasses
{
    public class SendingMail
    {
        private InfoEmailSending InfoEmailSending { get; set; }
        public SendingEmail(InfoEmailSending infoEmailSending)
        {
            InfoEmailSending = infoEmailSending
            ?? throw new ArgumentException(nameof(infoEmailSending));
        }


        public void Send()
        {
            // Добавляем обработку исключений
            try
            {

                SmtpClient mySmtpClient = new SmtpClient(InfoEmailSending.SmtpClientAdress);


                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.EnableSsl = true;


                NetworkCredential basicAuthenticationInfo = new NetworkCredential(
                    InfoEmailSending.EmailAdressFrom.EmailAdrress,
                    InfoEmailSending.EmailPassword);

                mySmtpClient.Credentials = basicAuthenticationInfo;


                MailAddress from = new MailAddress(
                    InfoEmailSending.EmailAdressFrom.EmailAdrress,
                    InfoEmailSending.EmailAdressFrom.Name);


                MailAddress to = new MailAddress(
                    InfoEmailSending.EmailAdressTo.EmailAdrress,
                    InfoEmailSending.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);


                MailAddress replyTo = new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdrress);
                myMail.ReplyToList.Add(replyTo);


                Encoding encoding = Encoding.UTF8;


                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;


                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;


                mySmtpClient.Send(myMail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
