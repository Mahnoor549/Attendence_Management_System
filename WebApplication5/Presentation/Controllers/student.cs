using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using AspNetCoreGeneratedDocument;
namespace Presentation.Controllers;

public class StudentController : Controller
{
    private readonly AttendenceDataBaseContext db;
    public StudentController(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public IActionResult Add()
    {
        ClassBAL s=new ClassBAL(db);
        List<TeacherClass> list= s.getALLClasses();
        ViewBag.list=list;
        return View();
    }
    [HttpPost]
    public IActionResult Add(string name,long CNIC,string email,int ClassId)
    {
        StudentBAL s=new StudentBAL(db);
        if (CNIC.ToString().Length == 13 && CNIC.ToString().All(char.IsDigit))
        {
        s.add(name, CNIC, email, ClassId);
        return RedirectToAction("Admin","Dashboard");
        }
        else{
        ViewBag.Message="Invalid CNIC number";
        ClassBAL s1=new ClassBAL(db);
        List<TeacherClass> list= s1.getALLClasses();
        ViewBag.list=list;
        return View();
        }

    }
    public IActionResult ViewStudents()
    {
         StudentBAL s=new StudentBAL(db);
         List<Student> list=s.displayStudents();
         ViewBag.list=list;
         ClassBAL c=new ClassBAL(db);
        List<TeacherClass> list1= c.getALLClasses();
        ViewBag.list1=list1;
        return View();

    }
    [HttpPost]
     public IActionResult ViewStudents(int classid)
    {
        StudentBAL a=new StudentBAL(db);
       List<Student> list= a.show(classid);
       ViewBag.list=list;
        ClassBAL c=new ClassBAL(db);
        List<TeacherClass> list1= c.getALLClasses();
        ViewBag.list1=list1;
       return View();

    }
}