using Microsoft.EntityFrameworkCore;

namespace DAL.Models;
public class FacultyDAL
{
    private readonly AttendenceDataBaseContext db;
    public FacultyDAL(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public void add(string name,long CNIC,string email,decimal salary,decimal tax)
    {
        Teacher t=new Teacher();
        t.Name=name;
        t.Cnic=CNIC;
        t.Email=email;
        t.Salary=salary;
        t.Tax=tax;
        db.Teachers.Add(t);
        db.SaveChanges();
    }
    public List<Teacher> GetAllTeachers()
    {
        List<Teacher> list=db.Teachers.ToList();
        return list;
    }
     public List<Teacher> getAllFaculty()
    {
        return db.Teachers.ToList();
    }
}