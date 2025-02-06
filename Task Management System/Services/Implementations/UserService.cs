using System.Security.Claims;
using Dapper;
using Task_Management_System.Data;
using Task_Management_System.ViewModels.AccountsViewModels;

namespace Task_Management_System.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DapperContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<UserService> _logger;

        public UserService(DapperContext context, IHttpContextAccessor contextAccessor, ILogger<UserService> logger)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _logger = logger;
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

        public int GetUserId()
        {
            //Note: In NameIdentifier we can store Id during the login process
            var userIdClaim = _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        public string GetUserName()
        {
            return _contextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(int userId)
        {
            using (var connection = _context.CreateConnection())
            {
                var roles = await connection.QueryAsync<string>(
                    "spGetUserRoles",
                    new { UserId = userId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                return roles;
            }
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            try
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
                            RoleName = "Employee"
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}
