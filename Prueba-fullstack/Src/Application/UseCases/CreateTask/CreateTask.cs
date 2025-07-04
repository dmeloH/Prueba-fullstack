using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.CreateTask
{
    public class CreateTask : ICreateTask
    {
        private readonly ITaskRepository _repo;

        public CreateTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<TaskList> Execute(TaskList task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                throw new ArgumentException("El título es obligatorio");

            return await _repo.CreateTask(task);
        }
    }
}
