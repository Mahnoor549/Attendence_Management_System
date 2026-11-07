using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Components.Forms;

namespace Presentation.Controllers;

public class DashboardController : Controller
{
    private readonly AttendenceDataBaseContext db;
    public DashboardController(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public IActionResult dashboard()
    {
        if(HttpContext.Session.GetString("LoggedInAdmin") == "true")
        {
        return RedirectToAction("Admin","Dashboard");
        }
        else
        {
        return RedirectToAction("Faculty","Dashboard");
        }
    }
    public IActionResult Admin()
    {
        if(HttpContext.Session.GetString("LoggedInAdmin") == "true")
        {
            StudentBAL s=new StudentBAL(db);
            int tStd=s.totalStudents();
            ViewBag.tStd=tStd;
            ClassBAL c=new ClassBAL(db);
            List<Records> rList=new List<Records>();
            List<TeacherClass> list=c.totalClassess();
            foreach(TeacherClass l in list)
            {
                AttendenceBAL a=new AttendenceBAL(db);
                Records r=a.getDetail(l.Name);
                rList.Add(r);
            }
            ViewBag.list=rList;
            return View();
        }
        else
        {
            return RedirectToAction("Admin","Login");
        }
    }
    public IActionResult Faculty()
    {
        if (HttpContext.Session.GetString("LoggedInFaculty") == "true")
        {
        ClassBAL s=new ClassBAL(db);
        string facultyName=HttpContext.Session.GetString("FacultyName");
        List<TeacherClass> list= s.getList(facultyName);
        int count=0;
        foreach(TeacherClass tc in list)
            {
                StudentBAL std=new StudentBAL(db);
                count+=std.totalStudentsByTeacher(tc.Id);
            }
            ViewBag.count=count;
            List<Records> rlist=new List<Records>();
            ClassBAL c=new ClassBAL(db);
            List<TeacherClass> t=c.getAllTeacherClass(facultyName);
            foreach(var teacher in t)
            {
                AttendenceBAL a=new AttendenceBAL(db);
                Records r=a.getDetail(teacher.Name);
                rlist.Add(r);
            }
             ViewBag.list=rlist;
            return View();
        }
        else
        {
            return RedirectToAction("Faculty","Login");
        }
    }
}
