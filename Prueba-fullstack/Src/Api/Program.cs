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
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuración de base de datos MySQL
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)))
        );

        // Inyección de dependencias
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();
        builder.Services.AddScoped<ICreateTask, CreateTask>();
        builder.Services.AddScoped<IGetAllTasks, GetAllTasks>();
        builder.Services.AddScoped<IUpdateTask, UpdateTask>();
        builder.Services.AddScoped<IDeleteTask, DeleteTask>();

        // Controladores y Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ✅ Política CORS para permitir peticiones desde el frontend
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

        var app = builder.Build();

        // Swagger solo en entorno de desarrollo
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // ✅ Redirección HTTPS (opcional pero recomendado)
        app.UseHttpsRedirection();

        // ✅ Habilitar CORS antes de cualquier autorización o mapeo
        app.UseCors("AllowFrontend");

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
