using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<TasksWithStatus>> GetAllTasksWithStatus(string? filterOn= null, string? filterQuery = null);
        Task<TasksWithStatus> GetTasksByIdAsync(int id);
        Task AddTasksAsync(TasksWithStatus tasksWithStatus);
        Task UpdateTasksAsync(TasksWithStatus tasksWithStatus);
        Task DeleteTasksAsync(int id);
    }
}
