using System.Data.Entity;

namespace TodoApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string conn = "DefaultConnection")
            : base(conn)
        {
        }

        public DbSet<Log> Logs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
