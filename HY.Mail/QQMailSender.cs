using HY.Mail.Base;

namespace HY.Mail
{
    public class QQMailSender : MailSender
    {
        private const string HOST = "smtp.qq.com";
        private const int PORT = 25;
        public QQMailSender(string mailAddress, string password) : base(HOST, PORT, mailAddress, password)
        {

        }

    }
}
