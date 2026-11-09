using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;

namespace MyAcademyPortfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        /* Burada Viewbag kullandım değiştiricem unutmaaa !!!*/
        /* ilk değer dönücek sadece*/
        public IViewComponentResult Invoke()
        {
            var values= _context.Abouts.ToList();
            ViewBag.v1 = _context.Abouts.Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.v2 = _context.Abouts.Select(x => x.JobTitle).FirstOrDefault();
            ViewBag.v3 = _context.Abouts.Select(x => x.Location).FirstOrDefault();
            ViewBag.v4 = _context.Abouts.Select(x => x.Expert).FirstOrDefault();
            ViewBag.v5 = _context.Abouts.Select(x => x.Email).FirstOrDefault();
            ViewBag.v6 = _context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.v7 = _context.Abouts.Select(x => x.OpenToWork).FirstOrDefault();
            return View(values);
        }
    }
}
