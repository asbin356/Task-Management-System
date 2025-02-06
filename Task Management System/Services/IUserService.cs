using Task_Management_System.ViewModels.AccountsViewModels;

namespace Task_Management_System.Services
{
    public interface IUserService
    {
        Task<AppUser> AuthenticateUserAsync(string username, string password);
        Task RegisterUserAsync(RegisterViewModel model);
    }
}
