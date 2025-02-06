namespace Task_Management_System.ViewModels.AccountsViewModels
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
