using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailApp.UserClasses;

namespace MailApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Проверка TextBox на наличие значений
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
                string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // Ввод данных с формы в объекты ранее созданных классов
            string smtp = "smtp.mail.ru";
            // Необходимо ввести свой mail.ru адрес!!! И свой ФИО
            StringPair fromInfo = new StringPair("почта", "ФИО Студента");
            // Необходимо ввести свой пароль который выдал mail.ru !!!
            string password = "пароль";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +
                          $"{Dns.GetHostName()} \n" +
                          $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                          $"{textBoxBody.Text}";

            InfoEmailSending info = new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);

            // Отправка данных в виде электронного письма
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            // Уведомления для пользователя и очистка всех TextBox
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }
    }
}
