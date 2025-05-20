using Microsoft.EntityFrameworkCore;
using SchoolManagerBackend.Models;

namespace SchoolManagerBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связей и индексов

            // Уникальность Username и Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Связь 1:1 User-Teacher
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId);

            // Связь 1:1 User-Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);

            // Связь Teacher-Class (классный руководитель)
            modelBuilder.Entity<Class>()
                .HasOne(c => c.ClassLeader)
                .WithMany(t => t.ClassesLed)
                .HasForeignKey(c => c.ClassLeaderId)
                .OnDelete(DeleteBehavior.SetNull);

            // Связь многие-ко-многим Teacher-Subject
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId);

            // Связь многие-ко-многим Student-Class
            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentId, sc.AcademicYear });

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentClasses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany(c => c.StudentClasses)
                .HasForeignKey(sc => sc.ClassId);

            // Связи для Grade
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Teacher)
                .WithMany(t => t.GradesGiven)
                .HasForeignKey(g => g.TeacherId);

            // Индексы для ускорения запросов
            modelBuilder.Entity<Grade>()
                .HasIndex(g => new { g.StudentId, g.SubjectId });

            modelBuilder.Entity<Grade>()
                .HasIndex(g => new { g.Period, g.AcademicYear });

            modelBuilder.Entity<StudentClass>()
                .HasIndex(sc => new { sc.StudentId, sc.ClassId, sc.AcademicYear });

            modelBuilder.Entity<TeacherSubject>()
                .HasIndex(ts => new { ts.TeacherId, ts.SubjectId });
        }
    }
}
