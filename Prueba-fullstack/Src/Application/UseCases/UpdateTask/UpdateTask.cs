using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.UpdateTask
{
    public class UpdateTask : IUpdateTask
    {
        private readonly ITaskRepository _repo;

        public UpdateTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Execute(int id, TaskList updatedTask)
        {
            return await _repo.UpdateTask(id, updatedTask);
        }
    }
}
