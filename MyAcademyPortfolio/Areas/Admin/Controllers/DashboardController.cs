using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProjects = _context.Projects.Count();
            ViewBag.TotalSkills = _context.SkillItems.Count();
            ViewBag.TotalExperiences = _context.Experiences.Count();
            ViewBag.TotalEducations = _context.Educations.Count();
            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewBag.LatestMessages = _context.Messages.OrderByDescending(x => x.SendDate).Take(5).ToList();

            return View();
        }
    }
}
