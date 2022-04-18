using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public class UserRepository : IUser
    {
        private ApplicationContext _context;

        public UserRepository()
        {
            _context = new ApplicationContext(DbContextHelper.GetDbContextOptions());
        }

        /// <summary>
        /// Поиск пользователя по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        public User FindUser(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Login == login || user.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }


        /// <summary>
        /// Получение пользователя по номеру
        /// </summary>
        /// <param name="id"></param>
        public User GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
