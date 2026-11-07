using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using DAL.Models;
using Microsoft.Data.SqlClient;

namespace Presentation.Controllers;
public class LoginController : Controller
{
    private readonly AttendenceDataBaseContext db;
    public LoginController(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public IActionResult Admin()
    {

        if(HttpContext.Session.GetString("LoggedInAdmin") == "true")
        {
            return RedirectToAction("Admin","Dashboard");
            
        }
        else
        {
            return View();
        }
    }
    [HttpPost]
     public IActionResult Admin(string username,string password)
    {
        HttpContext.Session.SetString("AdminUsername","admin");
        HttpContext.Session.SetString("Password","123");
        if (HttpContext.Session.GetString("AdminUsername") == username && HttpContext.Session.GetString("Password") == password)
        {
            HttpContext.Session.SetString("LoggedInAdmin", "true");
            return RedirectToAction("Admin","Dashboard");
        }
        else
        {
            ViewBag.Message="Invalid Username and password";
            return View();
        }
    }
     public IActionResult Faculty()
    {
        if(HttpContext.Session.GetString("LoggedInFaculty") == "true")
        {
            return RedirectToAction("Faculty","Dashboard");
            
        }
        else
        {
            return View();
        }
    }
    [HttpPost]
     public IActionResult Faculty(string username,int password)
    {
        string FacultyName=null;
        bool isexists = db.Teachers.Any(t => t.Name == username && t.Password == password);
        if (isexists)
        {
            HttpContext.Session.SetString("LoggedInFaculty", "true");
            HttpContext.Session.SetString("FacultyName",username);
            return RedirectToAction("Faculty","Dashboard");
        }
        else
        {
            ViewBag.Message="Invalid Username and password";
            return View();
        }
    }
}
