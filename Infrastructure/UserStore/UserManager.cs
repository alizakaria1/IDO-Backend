using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace Store.UserStore
{
    public class UserManager
    {
        private IUserRepository _userRespository;

        public UserManager(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }

        public async Task<Result> Register(User user)
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var registeredUser = await _userRespository.Register(user);

                    scope.Complete();

                    return Result.Ok(registeredUser);
                }
                catch (Exception ex)
                {

                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> Login(Login login)
        {
                try
                {
                    var user = await _userRespository.Login(login);

                    if(user == null)
                    {
                        return Result.Error("Incorrect Password");
                    }

                    var token = GenerateToken(user);

                    return Result.Ok(token);
                }
                catch (Exception ex)
                {
                    return Result.Error(ex.Message);
                }
        }

        public async Task<Result> UpdateUser(User user)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var updatedUser = await _userRespository.UpdateUser(user);

                    scope.Complete();

                    return Result.Ok(updatedUser);
                }
                catch (Exception ex)
                {
                    return Result.Error(ex.Message);
                }
            }
        }

        public async Task<Result> GetUser(int userId)
        {
            try
            {
                var user = await _userRespository.GetUser(userId);

                return Result.Ok(user);
            }
            catch (Exception ex)
            {

                return Result.Error(ex.Message);
            }
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ACDt1vR3lXToPQ1g3MyN"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim("Email", user.Email),
                new Claim("Image", user.Image)
            };
            var token = new JwtSecurityToken("https://localhost:7018/",
                "https://localhost:7018/",
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
