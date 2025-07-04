using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces
{
    /// <summary>
    /// Define el contrato para obtener todas las tareas existentes.
    /// </summary>
    public interface IGetAllTasks
    {
        /// <summary>
        /// Ejecuta la lógica para recuperar una colección de todas las tareas registradas.
        /// </summary>
        /// <returns>
        /// Una colección enumerable de objetos <see cref="TaskList"/> que representan las tareas.
        /// </returns>
        Task<IEnumerable<TaskList>> Execute();
    }
}
