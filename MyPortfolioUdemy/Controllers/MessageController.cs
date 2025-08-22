using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            // Retrieve messages from the database
            var messages = context.Messages.ToList();
            return View(messages);
        }
        public IActionResult ChangeIsReadtoTrue(int id)
        {
            // Find the message by ID
            var message = context.Messages.Find(id);
            if (message != null)
            {
                // Change IsRead property to true
                message.IsRead = true;
                context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }
        public IActionResult ChangeIsReadtoFalse(int id)
        {
            // Find the message by ID
            var message = context.Messages.Find(id);
            if (message != null)
            {
                // Change IsRead property to false
                message.IsRead = false;
                context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }
        public IActionResult DeleteMessage(int id)
        {
            var message = context.Messages.Find(id);
            if (message != null)
            {
                // Remove the message from the database
                context.Messages.Remove(message);
                context.SaveChanges();
            }
            return RedirectToAction("Inbox");
        }
        public IActionResult MessageDetail(int id)
        {
            var values = context.Messages.Find(id);
            return View(values);
        }
    }
}