using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRFrontend.Dtos.MailDtos;
using MailKit.Net.Smtp;

namespace SignalRFrontend.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Feane Restaurant", "bilgisayar.duolingo42@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMailAdress);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); ;

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bilgisayar.duolingo42@gmail.com", "mclx umnf wpri jyhx");

            client.Send(mimeMessage);
            client.Disconnect(true);


            return RedirectToAction("Index","AdminCategory");
        }
    }
}
