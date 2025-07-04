using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.CreateTask
{
    /// <summary>
    /// Caso de uso para la creación de una nueva tarea.
    /// Implementa la interfaz <see cref="ICreateTask"/>.
    /// </summary>
    public class CreateTask : ICreateTask
    {
        private readonly ITaskRepository _repo;

        /// <summary>
        /// Constructor que inyecta el repositorio de tareas.
        /// </summary>
        /// <param name="repo">Instancia de <see cref="ITaskRepository"/> para operaciones de persistencia.</param>
        public CreateTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica para crear una tarea.
        /// </summary>
        /// <param name="task">La entidad de la tarea a crear.</param>
        /// <returns>La tarea creada, incluyendo su identificador asignado.</returns>
        /// <exception cref="ArgumentException">Se lanza si el título de la tarea está vacío o es nulo.</exception>
        public async Task<TaskList> Execute(TaskList task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                throw new ArgumentException("El título es obligatorio");

            return await _repo.CreateTask(task);
        }
    }
}
