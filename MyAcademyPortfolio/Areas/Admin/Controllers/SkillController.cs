
using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill == null)
                return NotFound();

            return View(skill);
        }

        [HttpPost]
        public IActionResult DeleteSkill(Skill skill)
        {
            var values = _context.Skills.Find(skill.SkillId);

            if (values == null)
                return NotFound();

            _context.Skills.Remove(values);
            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
                return NotFound();
            return View(skill);
        }
        [HttpPost]  
        public IActionResult UpdateSkill(Skill skill)
        {
            var values = _context.Skills.Find(skill.SkillId);
            if (values == null)
                return NotFound();
            values.SkillTitle = skill.SkillTitle;
            values.SubTitle = skill.SubTitle;
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}
