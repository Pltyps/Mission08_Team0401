using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Mission08_Team0401.Models;
using Mission08_Team0401.Data;

//using Mission08_Team0401.Models;

namespace Mission08_Team0401.Controllers;

public class HomeController : Controller
{
    private TaskDbContext _context;

    public HomeController(TaskDbContext temp)
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Quadrants()
    {
        var tasks = _context.Tasks
            .Include(m => m.Category)  // Corrected, should be singular 'Category' if referring to the navigation property
            .ToList();  // Fetch tasks with related categories
    
        return View(tasks);  // Pass tasks to the view
    }

    
    [HttpGet]
    public IActionResult AddTask()
    {
        // Ensure categories are loaded and passed to the view
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View();
    }

    [HttpPost]
    public IActionResult AddTask(TaskItem response)
    {
        _context.Tasks.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var recordToEdit = _context.Tasks
            .Single(x=>x.TaskId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("AddTask",recordToEdit);
    }

    [HttpPost]
    public IActionResult Update(TaskItem updatedInfo)
    {
        _context.Tasks.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("Quadrants");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Tasks
            .Single(x => x.TaskId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(TaskItem recordToDelete)
    {
        _context.Tasks.Remove(recordToDelete);
        _context.SaveChanges();
        
        return RedirectToAction("Quadrants");
    }
}



