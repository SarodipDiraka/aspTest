using Microsoft.EntityFrameworkCore;
using asp.Models;

namespace asp.Data
{
    public class ToDoElementsContext(DbContextOptions<ToDoElementsContext> options) : DbContext(options)
    {
        public DbSet<ToDoElement> ToDoElements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoElement>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
            });
        }
    }
}