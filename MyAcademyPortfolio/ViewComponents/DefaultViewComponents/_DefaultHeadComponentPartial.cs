using Microsoft.AspNetCore.Mvc;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
