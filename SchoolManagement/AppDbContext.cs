using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Models;

namespace SchoolManagement
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Score>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Student_Scores)
                .HasForeignKey(si => si.StudentId);

            modelBuilder.Entity<Student_Score>()
                .HasOne(s => s.Score)
                .WithMany(st => st.Student_Scores)
                .HasForeignKey(si => si.ScoreId);
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Score> Scores { get; set; }

        public DbSet<Student_Score> Students_Scores { get; set; }

        public DbSet<Standard> Standards { get; set; }


    }
}
