
using Microsoft.AspNetCore.Mvc;
using MVCTemplate006.Models;


namespace MVCTemplate006.Controllers;

public class BookController : Controller
{
    
    private static List<Book> books = new List<Book>
    {
        new Book { id = 1, name = "Clean Code", price = 20 },
        new Book { id = 2, name = "ASP.NET MVC", price = 15 },
        new Book { id = 3, name = "Design Pattern", price = 25 }
    };

    
    public IActionResult Index()
    {
        return View(books);
    }

    
    [HttpGet]
    public IActionResult Detail(int id)
    {
        var book = books.FirstOrDefault(x => x.id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Book NewBooks)
    {
       
        if (!ModelState.IsValid)
        {
            
            return View(NewBooks);
        }

       
        int maxId = books.Max(x => x.id);
        NewBooks.id = maxId + 1;
        books.Add(NewBooks);
    
      
        ViewBag.Message = "Thêm sách mới thành công!";
        ViewBag.Status = "success";
    
        return View();
    }
}
