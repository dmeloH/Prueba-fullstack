using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Define el contrato para la creación de una nueva tarea.
    /// </summary>
    public interface ICreateTask
    {
        /// <summary>
        /// Ejecuta la lógica para crear una tarea.
        /// </summary>
        /// <param name="task">La entidad de la tarea que se desea crear.</param>
        /// <returns>La tarea creada con su identificador generado.</returns>
        Task<TaskList> Execute(TaskList task);
    }
}
