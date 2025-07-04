using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Prueba_fullstack.Src.Domain.Entities;

namespace Api.Controllers
{
    /// <summary>
    /// Controlador encargado de manejar las operaciones relacionadas con las tareas (Tasks).
    /// Expone endpoints para crear, obtener, actualizar y eliminar tareas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ICreateTask _createTask;
        private readonly IGetAllTasks _getAllTasks;
        private readonly IUpdateTask _updateTask;
        private readonly IDeleteTask _deleteTask;

        /// <summary>
        /// Constructor que recibe las dependencias necesarias mediante inyección de dependencias.
        /// </summary>
        public TasksController(
            ICreateTask createTask,
            IGetAllTasks getAllTasks,
            IUpdateTask updateTask,
            IDeleteTask deleteTask)
        {
            _createTask = createTask;
            _getAllTasks = getAllTasks;
            _updateTask = updateTask;
            _deleteTask = deleteTask;
        }

        /// <summary>
        /// Obtiene todas las tareas registradas.
        /// </summary>
        /// <returns>Una lista de tareas.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> Get()
        {
            var tasks = await _getAllTasks.Execute();
            return Ok(tasks);
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="task">Objeto de tipo TaskList con los datos de la tarea a crear.</param>
        /// <returns>La tarea creada.</returns>
        [HttpPost]
        public async Task<ActionResult<TaskList>> Post([FromBody] TaskList task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
                return BadRequest("El título de la tarea no puede estar vacío.");

            try
            {
                var created = await _createTask.Execute(task);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Marca una tarea como completada.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <returns>NoContent si la operación fue exitosa, NotFound si no se encontró la tarea.</returns>
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var partialTask = new TaskList
            {
                Title = string.Empty, // El título no se actualiza
                IsCompleted = true
            };

            var success = await _updateTask.Execute(id, partialTask);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Identificador de la tarea.</param>
        /// <param name="updatedTask">Objeto con los datos actualizados.</param>
        /// <returns>NoContent si la operación fue exitosa, NotFound si no se encontró la tarea.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskList updatedTask)
        {
            if (updatedTask == null || string.IsNullOrWhiteSpace(updatedTask.Title))
                return BadRequest("El título de la tarea no puede estar vacío.");

            var success = await _updateTask.Execute(id, updatedTask);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Elimina una tarea por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la tarea a eliminar.</param>
        /// <returns>NoContent si la operación fue exitosa, NotFound si no se encontró la tarea.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _deleteTask.Execute(id);
            return success ? NoContent() : NotFound();
        }
    }
}
