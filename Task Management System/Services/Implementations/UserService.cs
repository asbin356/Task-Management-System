using System.Data;
using System.Security.Claims;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Task_Management_System.Data;
using Task_Management_System.Models;
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

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<AppUser>
                    ("spGetAllUsers", commandType: CommandType.StoredProcedure);
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

        public Task<IEnumerable<AppUser>> GetUsersByEmailandUsernameAsync(string email, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetUsersByEmailAsync(string email)
        {
            using (var connection = _context.CreateConnection())
            {
                if (email == null)
                {
                    return await connection.QueryAsync<AppUser>
                       ("spGetAllUsers", commandType: CommandType.StoredProcedure);

                }
                else
                {
                    var users = await connection.QueryAsync<AppUser>(
                        "GetUsersByEmail",
                        new { Email = email },
                        commandType: System.Data.CommandType.StoredProcedure
                        );
                    return users;
                }
            }
        }

        public async Task<IEnumerable<AppUser>> GetUsersByFilterAsync(string email, string username)
        {
            using (var connection = _context.CreateConnection())
            {
                if (email == null && username == null)
                {
                    return await connection.QueryAsync<AppUser>
                   ("spGetAllUsers", commandType: CommandType.StoredProcedure);
                }
                var users = await connection.QueryAsync<AppUser>(
                    "GetUsersByFilter",
                    new { Email = email, Username = username },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                return users;
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
