using Microsoft.AspNetCore.Mvc;
using MVPTemplate003.Models;


namespace MVPTemplate003.Controllers;

public class StudentController : Controller
{
    public IActionResult Info()
    {
        ViewBag.Name = "Nguyen Van A";
        ViewData["Age"] = 20;

        Student student = new Student();
        {
            student.Major = "IT";
        }
        
        return View(student);
    }
}