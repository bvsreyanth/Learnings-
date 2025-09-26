using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Db_FirstApproach.Models;

public partial class EfDemoDbContext : DbContext
{
    public EfDemoDbContext()
    {

    }

    public EfDemoDbContext(DbContextOptions<EfDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Standard> Standards { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<VwStudentCourse> VwStudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultSQLConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7ED7A4F01");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Course__TeacherI__3B75D760");
        });

        modelBuilder.Entity<Standard>(entity =>
        {
            entity.HasKey(e => e.StandardId).HasName("PK__Standard__BB33D20C0FD883F9");

            entity.ToTable("Standard");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StandardName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B997AECD191");

            entity.ToTable("Student");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Standard).WithMany(p => p.Students)
                .HasForeignKey(d => d.StandardId)
                .HasConstraintName("FK__Student__Standar__3E52440B");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Cours__44FF419A"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Stude__440B1D61"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId").HasName("PK__StudentC__5E57FC836A2784A2");
                        j.ToTable("StudentCourse");
                    });
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__StudentA__32C52B9922E64440");

            entity.ToTable("StudentAddress");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.StudentAddress)
                .HasForeignKey<StudentAddress>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentAd__Stude__412EB0B6");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259649FCBB7B7");

            entity.ToTable("Teacher");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Standard).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.StandardId)
                .HasConstraintName("FK__Teacher__Standar__38996AB5");
        });

        modelBuilder.Entity<VwStudentCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwStudentCourse");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
