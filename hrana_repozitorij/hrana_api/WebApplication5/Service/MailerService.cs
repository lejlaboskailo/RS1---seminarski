using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Xml.Linq;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Helper;

namespace WebApplication5.Service
{
    public class MailerService: IEmailService
    {
        EmailSettings _emailSettings = null;
        ApplicationDbContext _dbContext;

        public MailerService(IOptions<EmailSettings> emailSettings, ApplicationDbContext context)
        {
            _emailSettings = emailSettings.Value;
            _dbContext = context;
        }

        public void sendMail(String message)
        {
            LogKretanjePoSistemu log = new LogKretanjePoSistemu();
            log.ExceptionMessage = message;
            log.isException = true;
            log.korisnikId = 1;
            log.QueryPath = "test";
            log.PostData = "test";
            log.Vrijeme = DateTime.Now;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var address = "";
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                     address = ip.ToString();
                }
            }
            log.IpAdresa = address;
            _dbContext.Add(log);
            _dbContext.SaveChanges();

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(_emailSettings.Host);
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(_emailSettings.EmailId, _emailSettings.Password);
            client.EnableSsl = true;
         
                MailMessage msg = new MailMessage();
                msg.From= new System.Net.Mail.MailAddress(_emailSettings.EmailId);
                msg.To.Add("lejlaboskailo18@gmail.com");// Mail would be sent to this address
                msg.Subject = "Error tracer";
                msg.Body = message;

                client.Send(msg);
        }
    }
}
