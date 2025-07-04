using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.GetAllTasks
{
    /// <summary>
    /// Caso de uso para obtener todas las tareas existentes.
    /// Implementa la interfaz <see cref="IGetAllTasks"/>.
    /// </summary>
    public class GetAllTasks : IGetAllTasks
    {
        private readonly ITaskRepository _repo;

        /// <summary>
        /// Constructor que recibe el repositorio de tareas a través de inyección de dependencias.
        /// </summary>
        /// <param name="repo">Instancia de <see cref="ITaskRepository"/> que permite acceder a los datos.</param>
        public GetAllTasks(ITaskRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica para recuperar todas las tareas almacenadas.
        /// </summary>
        /// <returns>
        /// Una colección de objetos <see cref="TaskList"/> que representan las tareas disponibles.
        /// </returns>
        public async Task<IEnumerable<TaskList>> Execute()
        {
            return await _repo.GetAllTasks();
        }
    }
}
