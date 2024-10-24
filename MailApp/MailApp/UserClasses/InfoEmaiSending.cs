using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.UserClasses
{
    public class StringPair
    {
        public StringPair(string emailAdress, string name)
        {
            EmailAdress = String.IsNullOrWhiteSpace(emailAdress) ?
            throw new Exception("Нельзя оставлять пустым") :
            emailAdress;

            Name = String.IsNullOrWhiteSpace(name) ?
            throw new Exception("Нельзя оставлять пустым") :
            name;
        }

        public string EmailAdress { get; set; }
        public string Name { get; set; }
    }
    internal class InfoEmailSending
    {
        public InfoEmailSending(string smtpClientAddress,
            StringPair emailAdressFrom,
            string emailPassword,
            StringPair emailAdressTo,
            string subject,
            string body)
        {
            smtpClientAddress = String.IsNullOrWhiteSpace(smtpClientAddress) ?
                throw new Exception("Нельзя вставлять пробелы или пустое значение!") : smtpClientAddress;

            EmailAdressFrom = emailAdressFrom ?? throw new ArgumentNullException(nameof(emailAdressFrom));
            EmailPassword = String.IsNullOrWhiteSpace(emailPassword) ?
                throw new Exception("Нельзя вставлять пробелы или пустое значение!") : emailPassword;

            EmailAdressTo = emailAdressTo ?? throw new ArgumentNullException(nameof(emailAdressTo));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string SmtpClientAddress { get; set; }
        public StringPair EmailAdressFrom { get; set; }
        public string EmailPassword { get; set; }
        public StringPair EmailAdressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
