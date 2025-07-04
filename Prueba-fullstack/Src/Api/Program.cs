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

        // Registro de repositorio
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();

        // Casos de uso - interfaces con sus implementaciones
        builder.Services.AddScoped<ICreateTask, CreateTask>();
        builder.Services.AddScoped<IGetAllTasks, GetAllTasks>();
        builder.Services.AddScoped<IUpdateTask, UpdateTask>();
        builder.Services.AddScoped<IDeleteTask, DeleteTask>();

        // Agregar soporte para controladores y Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Middleware de desarrollo
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
