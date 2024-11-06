using ProjetoFinal1.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Messages.Helpers
{
    public class MailHelper
    {
        #region Attributes

        private static string _account = "sergiojavaarq@outlook.com";
        private static string _password = "@Admin12345";
        private static string _smtp = "smtp-mail.outlook.com";
        private static int _door = 587;

        #endregion

        #region Method to send an email

        public static void SendMail(EmailServiceModel message)
        {
            //creating the email
            var mailMessage = new MailMessage
                (_account, message.EmailReceiver); //from -> to
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Message;

            //sending the email
            var smtpClient = new SmtpClient(_smtp, _door);

            //connecting to server
            smtpClient.Credentials = new NetworkCredential(_account, _password);

            //authenticating account
            smtpClient.EnableSsl = true;

            //encryption the email
            smtpClient.Send(mailMessage);

        }

        #endregion
    }
}
