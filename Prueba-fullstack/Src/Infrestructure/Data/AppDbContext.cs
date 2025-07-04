using Microsoft.EntityFrameworkCore;
using Prueba_fullstack.Src.Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskList> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones opcionales: puedes definir tablas, restricciones, etc.
            modelBuilder.Entity<TaskList>().ToTable("Tasks");
        }
    }
}
