namespace SULS.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class UserRegisterBindingModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string EmailErrorMessage = "Invalid username length! Must be between 5 and 50 symbols!";

        private const string PasswordErrorMessage = "Invalid password length!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }
    }
}