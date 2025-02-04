using Dapper;
using System.Data;
using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Services.Implementations
{
    public class TasksService : ITasksService
    {
        private readonly DapperContext _context;

        public TasksService(DapperContext context)
        {
            _context = context;
        }

        public async Task AddTasksAsync(TasksWithStatus tasksWithStatus)
        {
            var parameters = new
            {
                tasksWithStatus.Title,
                tasksWithStatus.Description,
                tasksWithStatus.Status,
                tasksWithStatus.CreatedAt,
                tasksWithStatus.DueDate
            };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spAddTasks", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteTasksAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spDeleteTasks", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TasksWithStatus>> GetAllTasksWithStatus()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TasksWithStatus>
                    ("spGetAllTasksWithStatus", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TasksWithStatus> GetTasksByIdAsync(int id)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QuerySingleOrDefaultAsync<TasksWithStatus>("spGetTasksById", new { Id = id },
                        commandType: CommandType.StoredProcedure);
                    if (result == null)
                    {
                        throw new Exception($"Task with Id {id} not found!");
                    }
                    return result;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateTasksAsync(TasksWithStatus tasksWithStatus)
        {
            var parameters = new
            {
                tasksWithStatus.Id,
                tasksWithStatus.Title,
                tasksWithStatus.Description,
                tasksWithStatus.Status,
                tasksWithStatus.CreatedAt,
                tasksWithStatus.DueDate
            };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spUpdateTasks", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
