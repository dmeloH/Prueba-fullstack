// using Application.Interfaces...
using Application.Interfaces;
using Application.UseCases.CreateTask;
using Application.UseCases.DeleteTask;
using Application.UseCases.GetAllTasks;
using Application.UseCases.UpdateTask;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    /// <summary>
    /// Punto de entrada principal de la aplicación ASP.NET Core.
    /// Configura los servicios y el pipeline HTTP.
    /// </summary>
    public static void Main(string[] args)
    {
        // Crea el builder de la aplicación
        var builder = WebApplication.CreateBuilder(args);

        // Configura la cadena de conexión a la base de datos MySQL
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)))
        );

        // Inyección de dependencias para el repositorio y los casos de uso
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();
        builder.Services.AddScoped<ICreateTask, CreateTask>();
        builder.Services.AddScoped<IGetAllTasks, GetAllTasks>();
        builder.Services.AddScoped<IUpdateTask, UpdateTask>();
        builder.Services.AddScoped<IDeleteTask, DeleteTask>();

        // Registra los controladores y servicios necesarios para el API
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); // Para exponer endpoints a Swagger
        builder.Services.AddSwaggerGen();          // Habilita generación de documentación Swagger

        // Configura CORS para permitir llamadas desde el frontend (por ejemplo, Vite)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });

        // Construye la aplicación
        var app = builder.Build();

        // Middleware de desarrollo: Swagger para documentación interactiva
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Aplica la política CORS definida anteriormente
        app.UseCors("AllowFrontend");

        // Middleware de autorización (si aplica)
        app.UseAuthorization();

        // Mapea los controladores a las rutas correspondientes
        app.MapControllers();

        // Ejecuta la aplicación
        app.Run();
    }
}
