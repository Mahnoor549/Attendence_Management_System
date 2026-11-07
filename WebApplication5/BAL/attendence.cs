using DAL.Models;

public class AttendenceBAL
{
    private readonly AttendenceDataBaseContext db;
    public AttendenceBAL(AttendenceDataBaseContext context)
    {
      db=context;
    }
    public List<Attendence>  show(int id,DateOnly date)
    {
        AttendenceDAL a=new AttendenceDAL(db);
        return a.show( id, date);
    }
    public void save(List<Attendence> list,DateOnly date)
    {
        AttendenceDAL a=new AttendenceDAL(db);
        a.save(list,date);
    }
    public Records getDetail(string name)
    {
        AttendenceDAL a1=new AttendenceDAL(db);
       Records r= a1.getAttendenceRecord(name);
       return r;
    }
}