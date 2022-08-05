using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using System.Threading;
using Google.Apis.Util;
using MailKit.Security;
using MailKit.Net.Imap;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Berk's Message", "ahandersonfi@gmail.com"));

            message.To.Add(MailboxAddress.Parse("berkozkanjp@gmail.com"));

            message.Subject = "First Test Email";
            message.Body = new TextPart("plain")
            {

                Text = @"<h1>Hello World</h1>"

            };

            string emailAddress = "ahandersonfi@gmail.com";
            string password = "rvtlfwysnzwyncwb";

            SmtpClient client = new SmtpClient();

            try 
	        {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                client.Send(message);
                Console.WriteLine("Email Sent!");
	        }
	        catch (global::System.Exception ex)
	        {
                Console.WriteLine(ex.Message);
	        }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            //Console.ReadLine();




        }
        
        
        
    }
}

