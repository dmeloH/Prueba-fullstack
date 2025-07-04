using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Define el contrato para actualizar una tarea existente.
    /// </summary>
    public interface IUpdateTask
    {
        /// <summary>
        /// Ejecuta la lógica de actualización de una tarea.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a actualizar.</param>
        /// <param name="task">Los nuevos datos que se aplicarán a la tarea.</param>
        /// <returns>
        /// True si la tarea fue actualizada correctamente; de lo contrario, false.
        /// </returns>
        Task<bool> Execute(int id, TaskList task);
    }
}
