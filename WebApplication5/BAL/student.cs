using DAL.Models;
public class StudentBAL
{
     private readonly AttendenceDataBaseContext db;
    public StudentBAL(AttendenceDataBaseContext context)
    {
      db=context;
    }
    public void add(string name,long CNIC,string email,int classId)
    {
        StudentDAL s=new StudentDAL(db);
        s.add( name, CNIC, email, classId);
    }
    public dynamic show(int id)
  {
    StudentDAL s =new StudentDAL(db);
    return s.show(id);
  }
  public int totalStudents()
  {
    StudentDAL std=new StudentDAL(db);
    return std.getStudents();
  }
  public int totalStudentsByTeacher(int id)
  {
    StudentDAL std=new StudentDAL(db);
    return std.getStudentsByTeacher(id);
  }
  public List<Student> displayStudents()
  {
    StudentDAL s1=new StudentDAL(db);
    List<Student> list=s1.getAllStudents();
    return list;
  }
}