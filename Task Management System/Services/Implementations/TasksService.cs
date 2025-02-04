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
        public async Task<IEnumerable<TasksWithStatus>> GetAllTasksWithStatus()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TasksWithStatus>
                    ("spGetAllTasksWithStatus", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
