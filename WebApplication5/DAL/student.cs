using Microsoft.EntityFrameworkCore;

namespace DAL.Models;
public class StudentDAL
{
    private readonly AttendenceDataBaseContext db;
    public StudentDAL(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public void add(string name,long CNIC,string email,int classId)
    {
        Student s=new Student();
        s.Name=name;
        s.Cnic=CNIC;
        s.Email=email;
        s.ClassId=classId;
        db.Students.Add(s);
        db.SaveChanges();
    }
    public List<Student> show(int id)
    {
        List<Student> list= db.Students.Where(s=>s.ClassId==id).ToList();
        return list;
    }
    public int getStudents()
    {
        int count=db.Students.Count();
        return count;
    }
     public int getStudentsByTeacher(int id)
    {
        int count=db.Students.Where(s=>s.ClassId==id).Count();
        return count;
    }
    public List<Student> getAllStudents()
    {
        return db.Students.ToList();
    }
}