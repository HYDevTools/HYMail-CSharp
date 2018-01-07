# HYMail-CSharp
 HY Mail is a simple and tiny mail tool.   


### Default Define QQMailSender 
```csharp
    public class QQMailSender : MailSender
    {
        private const string HOST = "smtp.qq.com";
        private const int PORT = 25;
        public QQMailSender(string mailAddress, string password) : base(HOST, PORT, mailAddress, password)
        {

        }

    } 
```
    
### Useage:
```csharp
  var Sender = new QQMailSender("XXXXXXXXXX@qq.com", "XXXXXXXXXXXXXXXX");
            Sender.Send("XXXXXXXXX@qq.com", "测试邮件", "邮件正文");
```
### Advance Useage
