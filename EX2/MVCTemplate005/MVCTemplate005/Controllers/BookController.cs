using Microsoft.AspNetCore.Mvc;
using MVCTemplate005.Models;

namespace MVCTemplate005.Controllers;

public class BookController : Controller
{
    private static List<Book> books = new List<Book>
    {
        new Book{id = 1, name = "book1", price = 20},
        new Book{id = 2, name = "book2", price = 20.5},
        new Book{id = 3, name = "book3", price = 31.2}
        
    };

    public IActionResult Index()
    {
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(x => x.id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View("Detail", book);
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
        ViewBag.Message = "thành công";
        ViewBag.Status = "success";
        return View();
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
    
    
}
