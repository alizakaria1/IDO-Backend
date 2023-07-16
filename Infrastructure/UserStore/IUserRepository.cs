using Core.Entities;

namespace Store.UserStore
{
    public interface IUserRepository
    {
        Task<User> Register(User user);

        Task<User> Login(Login login);

        Task<User> UpdateUser(User user);

        Task<User> GetUser(int userId);
    }
}
