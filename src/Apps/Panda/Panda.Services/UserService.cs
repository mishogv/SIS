namespace Panda.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using Domain;

    public class UserService : IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext pandaDbContext)
        {
            this.context = pandaDbContext;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users.SingleOrDefault(user => (user.Username == username || user.Email == username)
                                                              && user.Password == password);
        }

        public IEnumerable<string> GetAllUsernames()
        {
            return this.context.Users.Select(x => x.Username);
        }

        public User GetUserByUsername(string username)
        {
            return this.context.Users.FirstOrDefault(x => x.Username == username);
        }

        public User GetById(string id)
        {
            return this.context.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}
