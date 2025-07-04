using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces
{
    public interface ICreateTask
    {
        Task<TaskList> Execute(TaskList task);
    }
}