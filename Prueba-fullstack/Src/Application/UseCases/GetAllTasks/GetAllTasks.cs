using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;

namespace Application.UseCases.GetAllTasks
{
    public class GetAllTasks : IGetAllTasks
    {
        private readonly ITaskRepository _repo;

        public GetAllTasks(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskList>> Execute()
        {
            return await _repo.GetAllTasks();
        }
    }
}
