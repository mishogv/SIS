namespace SULS.Services
{
    using System.Linq;

    using Data;

    using Models;

    public class UserService : IUserService
    {
        private readonly SULSContext context;

        public UserService(SULSContext sulsDbContext)
        {
            this.context = sulsDbContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username)
                                                              && user.Password == password);
        }
    }
}