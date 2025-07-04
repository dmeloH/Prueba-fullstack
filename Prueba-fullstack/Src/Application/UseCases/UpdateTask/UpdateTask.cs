using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.UpdateTask
{
    /// <summary>
    /// Caso de uso para actualizar una tarea existente.
    /// Implementa la interfaz <see cref="IUpdateTask"/>.
    /// </summary>
    public class UpdateTask : IUpdateTask
    {
        private readonly ITaskRepository _repo;

        /// <summary>
        /// Constructor que inyecta el repositorio de tareas.
        /// </summary>
        /// <param name="repo">Instancia de <see cref="ITaskRepository"/> utilizada para acceder a los datos.</param>
        public UpdateTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica de actualización de una tarea.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a actualizar.</param>
        /// <param name="updatedTask">Entidad con los datos actualizados.</param>
        /// <returns>
        /// <c>true</c> si la tarea fue actualizada correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        public async Task<bool> Execute(int id, TaskList updatedTask)
        {
            return await _repo.UpdateTask(id, updatedTask);
        }
    }
}
