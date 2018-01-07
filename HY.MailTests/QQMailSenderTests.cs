using Microsoft.VisualStudio.TestTools.UnitTesting;
using HY.Mail;

namespace Hy.Mail.Tests
{
    [TestClass()]
    public class QQMailSenderTests
    {
        [TestMethod()]
        public void QQMailSenderTest()
        {
            var test = new QQMailSender("XXXXXXXXXX@qq.com", "XXXXXXXXXXXXXXXX");
            test.Send("XXXXXXXXX@qq.com", "测试邮件", "邮件正文");
            Assert.IsTrue(true);
        }
    }
}