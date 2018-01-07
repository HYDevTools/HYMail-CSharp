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
            //var test = new QQMailSender("519544044@qq.com", "wjpygxjumutsbgdh");
            //test.Send("519544044@qq.com", "测试邮件", "邮件正文");
            var test2 = new QQMailSender("519544044@qq.com", "wjpygxjumutsbgdh", "519544044@qq.com", "519544044@qq.com");
            test2.Send("预设测试邮件", "邮件正文");
            Assert.IsTrue(true);
        }
    }
}