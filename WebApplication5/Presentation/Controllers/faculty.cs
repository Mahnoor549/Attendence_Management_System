using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using DAL.Models;

namespace Presentation.Controllers;
public class FacultyController : Controller
{
    private readonly AttendenceDataBaseContext db;
    public FacultyController(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(string name,long CNIC,string email,decimal salary,decimal tax)
    {
        FacultyBAL f=new FacultyBAL(db);
        if (CNIC.ToString().Length == 13 && CNIC.ToString().All(char.IsDigit))
        {
        f.add( name, CNIC, email, salary, tax);
        return RedirectToAction("Admin","Dashboard");
        }
        else{
        ViewBag.Message="Invalid CNIC number";
        return View();
        }
    }
    public IActionResult ViewFaculty()
    {
        FacultyBAL s=new FacultyBAL(db);
         List<Teacher> list=s.displayFaculty();
         ViewBag.list=list;
         return View();
    }
}