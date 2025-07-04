using Application.Interfaces;
using Prueba_fullstack.Src.Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskList>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskList> CreateTask(TaskList task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> CompleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        task.IsCompleted = true;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateTask(int id, TaskList updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        task.Title = updatedTask.Title;
        task.IsCompleted = updatedTask.IsCompleted;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

}

