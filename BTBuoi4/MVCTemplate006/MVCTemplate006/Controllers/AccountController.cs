using Microsoft.AspNetCore.Mvc;

namespace MVCTemplate006.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Message = "Vui long nhap day du ten dang nhap va mat khau.";
            ViewBag.Status = "danger";
            return View();
        }

        ViewBag.Message = "Dang nhap thanh cong.";
        ViewBag.Status = "success";
        return View();
    }
}
