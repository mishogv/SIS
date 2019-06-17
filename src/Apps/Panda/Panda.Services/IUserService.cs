namespace Panda.Services
{
    using System.Collections.Generic;

    using Domain;

    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);

        IEnumerable<string> GetAllUsernames();

        User GetUserByUsername(string username);

        User GetById(string id);
    }
}
