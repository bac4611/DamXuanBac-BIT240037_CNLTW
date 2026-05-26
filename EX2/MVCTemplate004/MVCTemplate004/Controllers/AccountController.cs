using Microsoft.AspNetCore.Mvc;
using MVCTemplate004.Models;
namespace MVCTemplate004.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Account model)
    {
        if (model.Username == "admin" && model.Password == "123")
        {
            ViewBag.Message = "thanh cong";
            ViewBag.status = "success";
        }
        else if(string.IsNullOrEmpty(model.Password))
        {
            ViewBag.Message = "nhap lai mk";
            ViewBag.status = "danger";
        }
        else
        {
            ViewBag.Message = "ko de trong";
            ViewBag.status = "warning";
        }
        return View();
    }
}