using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="TaskList"/>.
    /// Esta interfaz abstrae la lógica de persistencia para las tareas.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Obtiene todas las tareas almacenadas en la base de datos.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="TaskList"/>.</returns>
        Task<IEnumerable<TaskList>> GetAllTasks();

        /// <summary>
        /// Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">La entidad de tarea que se desea crear.</param>
        /// <returns>La tarea creada, incluyendo su identificador asignado.</returns>
        Task<TaskList> CreateTask(TaskList task);

        /// <summary>
        /// Marca una tarea como completada.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <returns>True si la operación fue exitosa; de lo contrario, false.</returns>
        Task<bool> CompleteTask(int id);

        /// <summary>
        /// Actualiza una tarea existente con nuevos datos.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a actualizar.</param>
        /// <param name="updatedTask">Los nuevos datos de la tarea.</param>
        /// <returns>True si la tarea fue actualizada correctamente; de lo contrario, false.</returns>
        Task<bool> UpdateTask(int id, TaskList updatedTask);

        /// <summary>
        /// Elimina una tarea de la base de datos.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; de lo contrario, false.</returns>
        Task<bool> DeleteTask(int id);
    }
}
