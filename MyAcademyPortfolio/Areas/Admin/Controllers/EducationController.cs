using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
       
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult EducationList()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }
        [HttpPost] /* Ekleme*/ /* DropDown Çekilcek Unutma*/
        public IActionResult AddEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var values = _context.Educations.Find(id);
            return View(values);
        }
        [HttpPost] 
        public IActionResult UpdateEducation(Education education)
        {
            var values = _context.Educations.Find(education.EducationId);
            values.Title = education.Title;
            values.SubTitle = education.SubTitle;
            values.Description = education.Description;
            values.Duration = education.Duration;
            values.Location = education.Location;
            _context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        /* Silme İşlemi Dikkat*/  /* Gerçekten Silmek  İstiyor musunuz */ /* Adını Unuttum*/
        /* public IActionResult DeleteEducation(int id)
         {
             var values = _context.Educations.Find(id);
             _context.Educations.Remove(values);
             _context.SaveChanges();
             return RedirectToAction("EducationList");
         }*/
        [HttpGet]
        public IActionResult DeleteEducation(int id)
        {
            var values = _context.Educations.Find(id);

            if (values == null)
                return NotFound();

            return View(values);
        }
        [HttpPost]
        public IActionResult DeleteEducation(Education educaiton)
        {
            var values = _context.Educations.Find(educaiton.EducationId);
            if (values == null)
                return NotFound();
            _context.Educations.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}
