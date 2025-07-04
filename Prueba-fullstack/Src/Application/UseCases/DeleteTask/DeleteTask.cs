using Application.Interfaces;

namespace Application.UseCases.DeleteTask
{
    public class DeleteTask : IDeleteTask
    {
        private readonly ITaskRepository _repo;

        public DeleteTask(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Execute(int id)
        {
            return await _repo.DeleteTask(id);
        }
    }
}
