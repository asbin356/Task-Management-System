using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<TasksWithStatus>> GetAllTasksWithStatus();
        Task<TasksWithStatus> GetTasksByIdAsync(int id);
        Task AddTasksAsync(TasksWithStatus tasksWithStatus);
        Task UpdateTasksAsync(TasksWithStatus tasksWithStatus);
        Task DeleteTasksAsync(int id);
    }
}
