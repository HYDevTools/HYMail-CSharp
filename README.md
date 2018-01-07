# HYMail-CSharp
 HY.Mail is a simple tiny high-performance and thread-safe mail package. 


### Default Define MyMailSender 
```csharp
   public class MyMailSender : MailSender
    {
        private const string HOST = "smtp.XX.com";
        private const int PORT = 25;
        public MyMailSender(string mailAddress, string password,string to="",string cc="",string title="") : base(HOST, PORT, mailAddress, password,to,cc)
        {

        }

    }
```
    
### Useage:
```csharp
  var Sender = new MyMailSender("XXXXXXXXXX@xx.com", "XXXXXXXXXXXXXXXX");
            Sender.Send("XXXXXXXXX@xx.com", "测试邮件", "邮件正文");=
```
### Advance Useage
#### Define MailSender Factory
```csharp
  public static class MyMailFactory
    {
        public static string test = string.Empty;
        public static myMailSender ToXXMailSender = new MyMailSender("XX@qq.com", "pwd","to@qq.com");
        public static myMailSender ToYYMailSender = new MyMailSender("YY@qq.com", "pwd","to@qq.com");
      
    }
     MyMailFactory.ToXXMailSender.Send("title","content")
```
