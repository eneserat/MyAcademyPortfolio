using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sitesettings=_context.SiteSettings.FirstOrDefault();
           
            ViewBag.InstagramUrl=sitesettings.InstagramUrl;
            ViewBag.LinkedınUrl=sitesettings.LinkedınUrl;
            ViewBag.GithubUrl=sitesettings.GithubUrl;
            return View();
        }
        public IActionResult DownloadCv()
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                "cv",
                "CV.pdf"
            );

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("CV dosyası bulunamadı.");
            }

            return PhysicalFile(
                filePath,
                "application/pdf",
                "EsrefEnesErat-CV.pdf"
            );
            
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            _context.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
