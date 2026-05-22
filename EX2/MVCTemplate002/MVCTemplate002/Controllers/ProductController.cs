using Microsoft.AspNetCore.Mvc;

namespace MVCTemplate3.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/Detail/5
        [Route("Product/Detail/{id?}")]
        public IActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.ProductId = id.Value;
                return View();
            }
            else
            {
                ViewBag.Error = "Error: No Product ID provided";
                return View();
            }
        }

        // GET: /Product/Category?name=Laptop
        [Route("Product/Category")]
        public IActionResult Category(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                ViewBag.CategoryName = name;
            }
            return View();
        }
    }
}