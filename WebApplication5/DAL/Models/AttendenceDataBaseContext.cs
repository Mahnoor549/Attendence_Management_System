using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class AttendenceDataBaseContext : DbContext
{
    public AttendenceDataBaseContext()
    {
    }

    public AttendenceDataBaseContext(DbContextOptions<AttendenceDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendence> Attendences { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherClass> TeacherClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AttendenceDataBase;User Id=sa;Password=Mahnoor@12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attenden__3214EC278EF69E52");

            entity.ToTable("Attendence");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Class).WithMany(p => p.Attendences)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__Class__4F7CD00D");

            entity.HasOne(d => d.Std).WithMany(p => p.Attendences)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__StdId__4E88ABD4");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC272145A09E");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Cnic, "UQ_Student_CNIC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Student__A9D1053408D1208C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cnic).HasColumnName("CNIC");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__ClassId__4BAC3F29");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC275EBCA5E5");

            entity.ToTable("Teacher");

            entity.HasIndex(e => e.Name, "UQ_NAME").IsUnique();

            entity.HasIndex(e => e.Cnic, "UQ_Teacher_CNIC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Teacher__A9D105342EB10775").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cnic).HasColumnName("CNIC");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasDefaultValueSql("(floor((1000)+rand()*(((9999)-(1000))+(1))))");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TeacherClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherC__3214EC272F4831DA");

            entity.ToTable("TeacherClass");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherClasses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeacherCl__Teach__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
