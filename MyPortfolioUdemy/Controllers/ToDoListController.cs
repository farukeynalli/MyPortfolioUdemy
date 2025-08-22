using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ToDoListController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.ToDoLists.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDoList()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            context.ToDoLists.Add(toDoList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteToDoList(int id)
        {
            var values = context.ToDoLists.Find(id);
            if (values != null)
            {
                context.ToDoLists.Remove(values);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            var values = context.ToDoLists.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            var values = context.ToDoLists.Update(toDoList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatustoTrue(int id)
        {
            // Find the message by ID
            var values = context.ToDoLists.Find(id);
            if (values != null)
            {
                // Change IsRead property to true
                values.Status = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatustoFalse(int id)
        {
            // Find the message by ID
            var message = context.ToDoLists.Find(id);
            if (message != null)
            {
                // Change IsRead property to false
                message.Status = false;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
    