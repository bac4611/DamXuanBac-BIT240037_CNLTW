using Microsoft.AspNetCore.Mvc;

namespace MVCTemplate001.Controllers;

public class ProductController : Controller
{
    public IActionResult Category(string name)
    {
        ViewBag.Category = name;
        return View();
    }
}
