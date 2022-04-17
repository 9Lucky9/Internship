using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public interface IUser
    {
        public User FindUser(string login, string password);
        public User GetUser(int id);
    }
}
