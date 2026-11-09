using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultEducationComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultEducationComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Educations.ToList();
          
            return View(values);
        }
    }
}
