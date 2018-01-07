using System.Net;
using System.Net.Mail;

namespace HY.Mail.Base
{
    public abstract class MailSender
    {
        private readonly MailAddress _fromMailAdress;
        private readonly NetworkCredential _fromNetworkCredential;
        private readonly SmtpClient _mailclient;
        public readonly string MailAddress;
        /// <summary>
        /// 初始化邮箱账户信息
        /// </summary>
        /// <param name="host">邮件服务器</param>
        /// <param name="port">端口号</param>
        /// <param name="mailAddress">邮件账户</param>
        /// <param name="password">邮件密码</param>
        public MailSender(string host, int port, string mailAddress, string password)
        {
            MailAddress = mailAddress;
            _fromMailAdress = new MailAddress(mailAddress);
            _fromNetworkCredential = new NetworkCredential(mailAddress, password);
            //设置邮件发送服务器
            _mailclient = new SmtpClient(host, port);
            //设置发送人的邮箱账号和密码
            _mailclient.Credentials = _fromNetworkCredential;
            //启用ssl,也就是安全发送
            _mailclient.EnableSsl = true;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="title">标题</param>
        /// <param name="content">正文</param>
        public virtual void Send(string to, string title, string content)
        {
            Send(to, "", title, content);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人,多个逗号隔开</param>
        /// <param name="title">标题</param>
        /// <param name="content">正文</param>
        public virtual void Send(string to, string cc, string title, string content)
        {
            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            message.From = _fromMailAdress;
            message.To.Add(to);
            //设置抄送人
            if (!string.IsNullOrEmpty(cc))
                message.CC.Add(cc);
            message.Subject = title;
            message.Body = content;
            _mailclient.Send(message);
        }
    }
}
