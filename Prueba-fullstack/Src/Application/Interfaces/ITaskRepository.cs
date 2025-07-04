using Prueba_fullstack.Src.Domain.Entities;

namespace Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskList>> GetAllTasks();
    Task<TaskList> CreateTask(TaskList task);
    Task<bool> CompleteTask(int id);
    Task<bool> UpdateTask(int id, TaskList updatedTask);
    Task<bool> DeleteTask(int id);
}
