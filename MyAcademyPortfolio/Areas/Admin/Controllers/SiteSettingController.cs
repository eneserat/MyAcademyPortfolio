using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiteSettingController : Controller
    {
        private readonly PortfolioContext _Context;

        public SiteSettingController(PortfolioContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var values = _Context.SiteSettings.ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSiteSetting (SiteSetting siteSetting)
        {
            _Context.Update(siteSetting);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
