using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    class Email
    {
        public static void Send_TXT(string folderWithFiles)
        {
            SmtpClient client = new SmtpClient("smtp.mail.ru", 2525); // указываем смтп сервер и порт, который мы будем использовать 
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("alesya.grigoreva.97@mail.ru", "dPLSyvcGy6jCuKfFcQcC");// Указываем логин и пароль для авторизации// "sveta98#N"); 


            string msgFrom = "alesya.grigoreva.97@mail.ru"; // от кого письмо 
            string msgTo = "alesya.grigoreva.97@mail.ru"; // кому письмо будет отправлено 
            string msgSubject = "Письмо автоматическое"; // тема пиьсма
            
            string msgBody = "Отправка файлов"; // тело письма

            MailMessage msg = new MailMessage(msgFrom, msgTo, msgSubject, msgBody); // Создаем письмо, из всего, что сделали выше
            
            Directory.GetFiles(folderWithFiles, "*.txt").ToList().ForEach(
    name => msg.Attachments.Add(new Attachment(name, MediaTypeNames.Text.Plain)));

            try
            {
                client.Send(msg); // Отправляем письмо 
                MessageBox.Show("Сообщение отправлено!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception p)
            {
                MessageBox.Show(p.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
