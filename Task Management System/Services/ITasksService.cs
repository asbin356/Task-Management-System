using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<TasksWithStatus>> GetAllTasksWithStatus();
    }
}
