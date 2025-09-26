using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
