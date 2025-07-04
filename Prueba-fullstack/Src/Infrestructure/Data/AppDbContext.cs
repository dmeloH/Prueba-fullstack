using Microsoft.EntityFrameworkCore;
using Prueba_fullstack.Src.Domain.Entities;

namespace Infrastructure.Data
{
    /// <summary>
    /// Representa el contexto de base de datos de la aplicación.
    /// Se encarga de configurar y mapear las entidades al esquema de base de datos utilizando Entity Framework Core.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor que recibe las opciones de configuración del contexto.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Representa la colección de tareas en la base de datos.
        /// </summary>
        public DbSet<TaskList> Tasks { get; set; }

        /// <summary>
        /// Configura el modelo usando Fluent API.
        /// Se ejecuta cuando se crea el modelo, permitiendo definir nombres de tabla, relaciones y restricciones.
        /// </summary>
        /// <param name="modelBuilder">Instancia de <see cref="ModelBuilder"/> utilizada para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapea la entidad TaskList a la tabla "Tasks"
            modelBuilder.Entity<TaskList>().ToTable("Tasks");
        }
    }
}
