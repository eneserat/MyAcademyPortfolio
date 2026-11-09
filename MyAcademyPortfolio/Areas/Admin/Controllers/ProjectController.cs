using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ProjectList()
        {
            var values = _context.Projects.Include(x => x.Category).Include(x => x.ProjectSkills).ThenInclude(ps => ps.SkillItem).ToList();   
         

            return View(values);
        }
        [HttpGet]
        /* ThenInclude ile ilişkili tabloları da dahil ederek verileri çekiyoruz. */ 
        public IActionResult CreateProject()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.SkillItems = _context.SkillItems.ToList();

            return View(new Project());
        }
        [HttpPost]
        public IActionResult CreateProject(Project project, List<int> SkillItemIds)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            foreach (var skillId in SkillItemIds)
            {
                ProjectSkill projectSkill = new ProjectSkill
                {
                    ProjectId = project.ProjectId,
                    SkillItemId = skillId
                };

                _context.ProjectSkills.Add(projectSkill);
            }

            _context.SaveChanges();

            return RedirectToAction("ProjectList");

        }
    }
}
