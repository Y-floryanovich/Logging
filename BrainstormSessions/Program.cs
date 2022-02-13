using System.Configuration;
using BrainstormSessions.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            MailHandler mail = new MailHandler();
            mail.SmtpHost = "12.123.2";
            mail.Port = "123";
            mail.To = "123@gail.com";
            mail.From = "123@gail.com";
            mail.SendEmail("Message");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(builder =>
                {
                    builder.AddLog4Net("log4net.config");
                });
    }
}
