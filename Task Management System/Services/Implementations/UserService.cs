using Dapper;
using Task_Management_System.Data;
using Task_Management_System.ViewModels.AccountsViewModels;

namespace Task_Management_System.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;

        public UserService(DapperContext context)
        {
            _context = context;
        }

        //Authentication/login process
        public async Task<AppUser> AuthenticateUserAsync(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<AppUser>
                    ("spAuthenticateUser",
                    new { Username = username },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return user;
                }
                return null;
            }
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(
                    "spAddUser",
                    new
                    {
                        model.Username,
                        model.Email,
                        PasswordHash = passwordHash,
                        RoleName = "Customer"
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }
    }
}
