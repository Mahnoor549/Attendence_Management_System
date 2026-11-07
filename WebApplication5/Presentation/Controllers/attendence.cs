using Microsoft.AspNetCore.Mvc;
using DAL.Models;

namespace Presentation.Controllers;
public class AttendenceController:Controller{
    private readonly AttendenceDataBaseContext db;
   static private  int facultyid{get;set;}
    public AttendenceController(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public IActionResult Show()
    {
        ClassBAL s=new ClassBAL(db);
        List<TeacherClass> list= s.getALLClasses();
        ViewBag.list=list;
        return View();
    }
    public IActionResult ShowStudents()
    {
        ClassBAL s=new ClassBAL(db);
        string facultyName=HttpContext.Session.GetString("FacultyName");
        List<TeacherClass> list= s.getList(facultyName);
        ViewBag.list=list;
        return View();
    }
    public IActionResult Show1(int classid,DateOnly date)
    {
        AttendenceBAL a=new AttendenceBAL(db);
       List<Attendence>  list= a.show( classid, date);
       return View(list);
    }
    public IActionResult SaveAttendence(List<Attendence> list,DateOnly date)
    {
        int classid=HttpContext.Session.GetInt32("classId").Value;
        AttendenceBAL a=new AttendenceBAL(db);
         int id=db.TeacherClasses.Where(f=>f.Id==classid).Select(f=>f.Id).FirstOrDefault();
        foreach(var item in list)
        {
            item.ClassId=id;
        }
        a.save(list,date);
        return RedirectToAction("Faculty", "Dashboard");
    }

    public IActionResult ShowStudents1(int classid){
        HttpContext.Session.SetInt32("classId",classid);
        string facultyName=HttpContext.Session.GetString("FacultyName");
        int id=db.Teachers.Where(f=>f.Name==facultyName).Select(f=>f.Id).FirstOrDefault();
        bool ifexists=db.TeacherClasses.Any(c=>c.Id==classid && c.TeacherId==id);
        if (ifexists)
        {
        StudentBAL a=new StudentBAL(db);
       List<Student> list= a.show(id);
       return View(list);
        }
        else
        {
            return RedirectToAction("ShowStudents", "Attendence",new{id=id});
        }
    }
    
}