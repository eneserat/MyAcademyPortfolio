using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultMessageComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultMessageComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IViewComponentResult Invoke()
        {

            return View();
        }


    }
}
