using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces

{
    public interface IUpdateTask
    {
        Task<bool> Execute(int id, TaskList task);
    }
}
