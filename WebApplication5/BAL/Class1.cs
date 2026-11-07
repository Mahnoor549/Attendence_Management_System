using DAL.Models;
public class ClassBAL
{
    private readonly AttendenceDataBaseContext db;
    public ClassBAL(AttendenceDataBaseContext context)
    {
      db=context;
    }
    public void Add(string name,int teacherid)
    {
        ClassDAL c=new ClassDAL(db);
        c.add(name, teacherid);
    }
    public List<TeacherClass> getList(string facultyName)
    {
        ClassDAL c=new ClassDAL(db);
        return c.GetList(facultyName);
        
    }
    public List<TeacherClass> getALLClasses()
    {
        ClassDAL c=new ClassDAL(db);
        return c.GetAllClasses();
    }
    public List<TeacherClass> getAllTeacherClass(string name)
    {
        ClassDAL c=new ClassDAL(db);
        return c.GetAllTeacherClasses(name);
    }
    public List<TeacherClass> totalClassess()
    {
        ClassDAL c=new ClassDAL(db);
        return c.CountClassess();
    }
}