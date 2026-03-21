using InlämningsUppgiftFullStackApplikation.Models;
using Microsoft.EntityFrameworkCore;

namespace InlämningsUppgiftFullStackApplikation.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
