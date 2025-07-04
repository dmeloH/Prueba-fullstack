using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Prueba_fullstack.Src.Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ICreateTask _createTask;
        private readonly IGetAllTasks _getAllTasks;
        private readonly IUpdateTask _updateTask;
        private readonly IDeleteTask _deleteTask;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> Get()
        {
            var tasks = await _getAllTasks.Execute();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskList>> Post([FromBody] TaskList task)
        {
            if (task == null)
                return BadRequest("Datos de la tarea inválidos.");

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

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var partialTask = new TaskList { Title = string.Empty, IsCompleted = true };
            var success = await _updateTask.Execute(id, partialTask);
            return success ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskList updatedTask)
        {
            if (updatedTask == null)
                return BadRequest("Datos de tarea inválidos.");

            var success = await _updateTask.Execute(id, updatedTask);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _deleteTask.Execute(id);
            return success ? NoContent() : NotFound();
        }
    }
}
