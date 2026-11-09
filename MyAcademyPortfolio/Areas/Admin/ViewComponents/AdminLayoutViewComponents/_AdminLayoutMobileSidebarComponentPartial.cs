using Microsoft.AspNetCore.Mvc;

namespace MyAcademyPortfolio.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMobileSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
             return View();
        }
    }
}
