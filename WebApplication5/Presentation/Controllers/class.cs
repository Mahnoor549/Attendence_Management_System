using Microsoft.AspNetCore.Mvc;
using DAL.Models;
namespace Presentation.Controllers;
public class ClassController : Controller
{
    private readonly AttendenceDataBaseContext db;
    public ClassController(AttendenceDataBaseContext context)
    {
        db=context;
    }

    public IActionResult Add()
    {
        FacultyBAL s=new FacultyBAL(db);
        List<Teacher> list= s.getALLTeachers();
        ViewBag.list=list;
        TempData["IsAllowed"] = true; 
        return View();
    }
    [HttpPost]
     public IActionResult Add(string  name,int teacherid)
    {
        ClassBAL c=new ClassBAL(db);
        c.Add(name, teacherid);
        TempData["IsAllowed"] = true; 
        return RedirectToAction("Admin","Dashboard");
    }
    public IActionResult ViewClass()
    {
        ClassBAL c=new ClassBAL(db);
         List<TeacherClass> list=c.getALLClasses();
         ViewBag.list=list;
         return View();
    }
}