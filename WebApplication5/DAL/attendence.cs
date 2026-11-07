using Microsoft.EntityFrameworkCore;

namespace DAL.Models;
public class AttendenceDAL
{
    private readonly AttendenceDataBaseContext db;
    public AttendenceDAL(AttendenceDataBaseContext context)
    {
        db=context;
    }
    public List<Attendence> show(int id,DateOnly date)
    {
        List<Attendence> list=db.Attendences.Where(l=> l.ClassId ==id && l.Date==date).ToList();
        return list;
    }
    public void save(List<Attendence> list,DateOnly date)
    {
        foreach(var item in list)
        {
            Attendence a=new Attendence();
            a.StdId=item.Id;
            a.ClassId=item.ClassId;
            a.Date=date;
            a.Name=item.Name;
            a.Status=item.Status;
            db.Attendences.Add(a);
        }
        db.SaveChanges();
    }
    public Records getAttendenceRecord(string name)
    {
        DateOnly today=DateOnly.FromDateTime(DateTime.Now);
        int classid=db.TeacherClasses.Where(c=>c.Name==name).Select(c=>c.Id).FirstOrDefault();
        int presentStd=db.Attendences.Where(a=>a.ClassId==classid&& a.Status=="Present"&&a.Date==today).Count();
        int absentStd=db.Attendences.Where(a=>a.ClassId==classid&& a.Status=="Absent"&&a.Date==today).Count();
        int lateStd=db.Attendences.Where(a=>a.ClassId==classid&& a.Status=="Late"&&a.Date==today).Count();
        Records r=new Records();
        r.className=name;
        r.present=presentStd;
        r.absent=absentStd;
        r.late=lateStd;
        return r;
    }
}