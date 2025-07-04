using Application.Interfaces;

namespace Application.UseCases.DeleteTask
{
    /// <summary>
    /// Caso de uso para eliminar una tarea existente.
    /// Implementa la interfaz <see cref="IDeleteTask"/>.
    /// </summary>
    public class DeleteTask : IDeleteTask
    {
        private readonly ITaskRepository _repo;

        /// <summary>
        /// Constructor que inyecta el repositorio de tareas.
        /// </summary>
        /// <param name="repo">Instancia de <see cref="ITaskRepository"/> usada para operaciones de persistencia.</param>
        public DeleteTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica para eliminar una tarea por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la tarea a eliminar.</param>
        /// <returns>
        /// <c>true</c> si la tarea fue eliminada correctamente; de lo contrario, <c>false</c>.
        /// </returns>
        public async Task<bool> Execute(int id)
        {
            return await _repo.DeleteTask(id);
        }
    }
}
