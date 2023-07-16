using Core.Entities;
using Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Store.UserStore
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int userId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var user = await _context.User.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                    return user;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<User> Login(Login login)
        {
            using (var context = new StoreContext())
            {
                try
                {

                    var user = await _context.User.FirstOrDefaultAsync(e => e.Email == login.Email && e.Password == login.Password);

                    if (user != null)
                    {
                        return user;
                    }

                    return null;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<User> Register(User user)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var createdUser = await _context.User.AddAsync(user);

                    await _context.SaveChangesAsync();

                    return createdUser.Entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var existingUser = await _context.User.FindAsync(user.UserId);

                    if (existingUser != null)
                    {
                        existingUser.UserName = user.UserName;
                        existingUser.Email = user.Email;
                        existingUser.Password = user.Password;
                        existingUser.Image = user.Image;

                        await _context.SaveChangesAsync();

                        return user;
                    }

                    return null;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
