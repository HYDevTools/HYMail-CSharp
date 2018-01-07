using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Mail;

namespace HY.Mail.Base
{
    public abstract class MailSender
    {
        private MailAddress _fromMailAdress;
        private readonly SmtpClient _mailclient;
        public readonly string MailAddress;
        public readonly string _to = string.Empty;
        public readonly string _cc = string.Empty;
        private static ConcurrentDictionary<string, SmtpClient> _mailClientDictionary = new ConcurrentDictionary<string, SmtpClient>();
        /// <summary>
        /// 初始化邮箱账户信息
        /// </summary>
        /// <param name="host">邮件服务器</param>
        /// <param name="port">端口号</param>
        /// <param name="mailAddress">邮件账户</param>
        /// <param name="password">邮件密码</param>

        public MailSender(string host, int port, string mailAddress, string password, string to = "", string cc = "", string title = "",bool enableSsl=true)
        {
            MailAddress = mailAddress;
            _mailclient = GetSmtpClient(host, port, mailAddress, password,enableSsl);
            _to = to;
            _cc = cc;
        }
        public SmtpClient GetSmtpClient(string host, int port, string from, string password, bool enableSsl = true)
        {
            var key = $"{host}_{port}_{from}_{password}";
            SmtpClient client = null;
            if (_mailClientDictionary.ContainsKey(key))
                _mailClientDictionary.TryGetValue(key, out client);
            else
            {
                _fromMailAdress = new MailAddress(from);
                //设置邮件发送服务器
                client = new SmtpClient(host, port);
                //设置发送人的邮箱账号和密码
                client.Credentials = new NetworkCredential(from, password);
                //启用ssl,也就是安全发送
                client.EnableSsl = enableSsl;
                _mailClientDictionary.TryAdd(key, client);
            }
            return client;
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
        public virtual void Send(string title, string content)
        {
            if (string.IsNullOrEmpty(_to))
                throw new ArgumentException("Mail Recevier Address Cannt Be Null: Constructor Must Set Recevier Mail Address", "_to");
            Send(_to, _cc, title, content);
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
            if (string.IsNullOrEmpty(_to))
                throw new ArgumentException("Mail Recevier Address Cannt Be Null", "to");
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
