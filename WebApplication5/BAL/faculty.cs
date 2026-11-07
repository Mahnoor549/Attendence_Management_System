using DAL.Models;
public class FacultyBAL
{
     private readonly AttendenceDataBaseContext db;
    public FacultyBAL(AttendenceDataBaseContext context)
    {
      db=context;
    }
    public void add(string name,long CNIC,string email,decimal salary,decimal tax)
    {
       FacultyDAL f=new FacultyDAL(db);
       f.add(name, CNIC, email, salary, tax) ;
    }
    public List<Teacher> getALLTeachers()
  {
    FacultyDAL c=new FacultyDAL(db);
        return c.GetAllTeachers();
  }
  public List<Teacher> displayFaculty()
  {
        FacultyDAL f1=new FacultyDAL(db);
    List<Teacher> list=f1.getAllFaculty();
    return list;
  }
}