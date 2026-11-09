using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultExperienceComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.Where(x => x.IsActive == true).ToList();

            return View(values);
        }
    }
}
