using Microsoft.AspNetCore.Mvc;
using MVCTemplate007.Models;

namespace MVCTemplate007.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (model.UserName == "admin" && model.Password == "123")
        {
            return RedirectToAction("Dashboard");
        }

        ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
        return View(model);
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        return View();
    }
}
