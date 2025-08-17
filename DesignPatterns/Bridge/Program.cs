using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    //aynı işlemi farklı classlar için yapmayı kolaylaştırma
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSenderBase = new EMailSender();
            customerManager.UpdateCustomer();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved!");
        }

        abstract public void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was sent via MailSender");
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was sent via SmsSender");
        }
    }

    class CustomerManager
    {
        public  MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Send(new Body {Title = "About the course!" });
            Console.WriteLine("Customer Updated");
        }
    }
}
