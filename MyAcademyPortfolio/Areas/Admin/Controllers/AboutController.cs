using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.FirstOrDefault();

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            var values = _context.Abouts.FirstOrDefault();
            if (values != null)
            {
                values.NameSurname = about.NameSurname;
                values.JobTitle = about.JobTitle;
                values.Location = about.Location;
                values.Expert = about.Expert;
                values.Email = about.Email;
                values.Description = about.Description;
                values.OpenToWork = about.OpenToWork;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}
