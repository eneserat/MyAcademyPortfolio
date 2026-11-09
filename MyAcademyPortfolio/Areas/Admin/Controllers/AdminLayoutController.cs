using Microsoft.AspNetCore.Mvc;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }                                           
    }
}
