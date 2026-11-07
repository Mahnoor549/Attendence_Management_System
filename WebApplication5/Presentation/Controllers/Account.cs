using Microsoft.AspNetCore.Mvc;
using DAL.Models;
namespace Presentation.Controllers;
public class AccountController : Controller
{
    public IActionResult Logout()
    {
        if(HttpContext.Session.GetString("LoggedInAdmin") == "true")
        {
        HttpContext.Session.Remove("LoggedInAdmin");
        return RedirectToAction("Admin","Login");
        }
        else
        {
        HttpContext.Session.Remove("LoggedInFaculty");
        return RedirectToAction("Faculty","Login");
        }
    }
}