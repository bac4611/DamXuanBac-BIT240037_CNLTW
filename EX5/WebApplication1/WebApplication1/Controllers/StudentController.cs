using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class StudentController : Controller
{
    private static List<Student> students = new List<Student>()
    {
        new Student {Id = 1, Name = "a", Email = "a@gmail.com", ClassName = "IT1", Score = 9.8},
        new Student {Id = 2, Name = "b", Email = "b@gmail.com", ClassName = "IT1", Score = 9.7},
        new Student {Id = 3, Name = "c", Email = "c@gmail.com", ClassName = "IT1", Score = 9.6},
        new Student {Id = 4, Name = "d", Email = "d@gmail.com", ClassName = "IT1", Score = 9.5},
    };

    public ActionResult Index()
    {
        return View(students);
    }
    
    public IActionResult Detail(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
        return View(student);
    }

    public IActionResult Edit(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    
    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var oldStudent = students.FirstOrDefault(s => s.Id == student.Id);

            if (oldStudent == null)
            {
                return NotFound();
            }

            oldStudent.Name = student.Name;
            oldStudent.Email = student.Email;
            oldStudent.ClassName = student.ClassName;
            oldStudent.Score = student.Score;

            return RedirectToAction("Index");
        }

        return View(student);
    }
    
    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        students.Remove(student);

        return RedirectToAction("Index");
    }
    
}