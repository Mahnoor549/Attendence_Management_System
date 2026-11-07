using Microsoft.EntityFrameworkCore;

namespace DAL.Models;
public class ClassDAL
{
    private readonly AttendenceDataBaseContext db;
    public ClassDAL(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public void add(string name,int teacherid)
    {
        TeacherClass c=new TeacherClass();
        c.Name=name;
        c.TeacherId=teacherid;
        db.TeacherClasses.Add(c);
        db.SaveChanges();
    }
    public List<TeacherClass> GetList(string facultyName)
    {
        int facultyid=db.Teachers.Where(f=>f.Name==facultyName).Select(f=>f.Id).FirstOrDefault();
        List<TeacherClass> list=db.TeacherClasses.Where(c=>c.TeacherId==facultyid).ToList();
        return list;
    }
    public List<TeacherClass> GetAllClasses()
    {
        List<TeacherClass> list=db.TeacherClasses.ToList();
        return list;
    }
    public List<TeacherClass> GetAllTeacherClasses(string name)
    {
        int id=db.Teachers.Where(c=>c.Name==name).Select(c=>c.Id).FirstOrDefault();
        List<TeacherClass> list=db.TeacherClasses.Where(t=>t.TeacherId==id).ToList();
        return list;
    }
    
    public List<TeacherClass> CountClassess()
    {
        return db.TeacherClasses.ToList();
    }
}