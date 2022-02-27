using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Infrastructure;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoListContext _db;

        public ToDoListController(ToDoListContext db)
        {
            _db = db;
        }
        // Get All => GET
        public IActionResult Index()
        {
            var lists = _db.ToDoList.ToList();

            return View(lists);
        }

        // Create => GET
        public ActionResult Create()
        {
            return View();
        }

        // Create => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create (ToDoList toDoList)
        {
            if(ModelState.IsValid)
            {
                _db.Add(toDoList);
                await _db.SaveChangesAsync();

                TempData["Save"] = "The Item Has Been Added";

                return RedirectToAction("Index");
            }
            return View(toDoList);
        }
        // Edit => GET
        public async Task<ActionResult> Edit(int id)
        {
            ToDoList toDoList = await _db.ToDoList.FindAsync(id);
            if(toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }
        // Edit => POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                _db.Update(toDoList);
                await _db.SaveChangesAsync();

                TempData["Edit"] = "The Item Has Been Updated";

                return RedirectToAction("Index");
            }
            return View(toDoList);
        }
        // Details => GET
        public async Task<ActionResult> Details(int id)
        {
            ToDoList toDoList = await _db.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }
        // Delete => GET
        public async Task<ActionResult> Delete(int id)
        {
            ToDoList toDoList = await _db.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                TempData["Error"] = "The Item Does Not Exist !!!";
            }
            else
            {
                _db.ToDoList.Remove(toDoList);
                await _db.SaveChangesAsync();

                TempData["Delete"] = "The Item Has Been Deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
