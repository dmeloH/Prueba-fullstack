using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces

{
    public interface IGetAllTasks
    {
        Task<IEnumerable<TaskList>> Execute();
    }
}
