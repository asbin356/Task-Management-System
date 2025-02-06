
using Dapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Task_Management_System.Data
{
    public class DataSeeder
    {
        private readonly DapperContext _context;

        public DataSeeder(DapperContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            await SeedRoleAsync();
            await SeedAdminAsync();
        }

        private async Task SeedAdminAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var adminUser = new
                {
                    Username = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = HashPassword("Admin@12345"),
                    RoleName = "Admin",
                };
                await connection.ExecuteAsync(
                    "spAddUser",
                    new
                    {
                        adminUser.Username,
                        adminUser.Email,
                        adminUser.PasswordHash,
                        adminUser.RoleName
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        private object HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private async Task SeedRoleAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var roles = new[]
                {
                    new{Name ="Admin"},
                    new{Name ="Employee"}
                };
                foreach (var role in roles)
                {
                    await connection.ExecuteAsync(
                        "spAddRole",
                        new { Name = role.Name },
                        commandType: System.Data.CommandType.StoredProcedure
                        );

                }
            }
        }
    }
}
