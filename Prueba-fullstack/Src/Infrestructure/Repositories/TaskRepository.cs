using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementación del repositorio de tareas.
    /// Encapsula la lógica de acceso a datos mediante Entity Framework Core.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">Instancia de <see cref="AppDbContext"/> para interactuar con la base de datos.</param>
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las tareas almacenadas.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="TaskList"/>.</returns>
        public async Task<IEnumerable<TaskList>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tipo <see cref="TaskList"/> que representa la nueva tarea.</param>
        /// <returns>La tarea creada con su identificador asignado.</returns>
        public async Task<TaskList> CreateTask(TaskList task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        /// <summary>
        /// Marca una tarea como completada.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <returns>
        /// <c>true</c> si la tarea fue encontrada y marcada como completada; <c>false</c> si no se encontró.
        /// </returns>
        public async Task<bool> CompleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza una tarea existente con nuevos valores.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <param name="updatedTask">Objeto con los datos actualizados.</param>
        /// <returns>
        /// <c>true</c> si la tarea fue actualizada correctamente; <c>false</c> si no se encontró.
        /// </returns>
        public async Task<bool> UpdateTask(int id, TaskList updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina una tarea de la base de datos.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <returns>
        /// <c>true</c> si la tarea fue eliminada correctamente; <c>false</c> si no se encontró.
        /// </returns>
        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
