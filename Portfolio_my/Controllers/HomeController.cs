using Microsoft.AspNetCore.Mvc;
using Portfolio_my.Models;
using System.Diagnostics;
using PortfolioMisc.Services.EmailService;
using PortfolioMisc.Models;
using Portfolio_my.Services;

namespace Portfolio_my.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;
        private IEmailService? _emailService;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendGmail(string name, string email, string mobileNumber, string formMessage)
        {
            EmailModel emailModel = new EmailModel
            {
                Name = name,
                Email = email,
                Subject = mobileNumber,
                Message = formMessage
            };

            _emailService = new EmailService();
            _emailService.SendGmail(emailModel);

            var emailModelFE = new EmailModel
            {
                Id = new Guid(),
                Name = name,
                Email = email,
                Subject = mobileNumber,
                Message = formMessage
            };
            _db.Mails.Add(emailModelFE);
            _db.SaveChanges();
            //return RedirectToAction("Index");
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}