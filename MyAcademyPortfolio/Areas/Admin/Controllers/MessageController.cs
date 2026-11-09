using Microsoft.AspNetCore.Mvc;
using MyAcademyPortfolio.Context;
using MyAcademyPortfolio.Entities;

namespace MyAcademyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
        public IActionResult CreateMessage()
        {
              return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            _context.Add(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public IActionResult MessageDetail(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            value.IsRead = true;
            _context.SaveChanges();

            return View(value);
        }
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }
    }
}
