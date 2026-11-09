using Microsoft.AspNetCore.Mvc;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
