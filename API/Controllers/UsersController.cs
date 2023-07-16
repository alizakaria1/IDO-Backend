using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.UserStore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var registeredUser = await _userManager.Register(user);

                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var user = await _userManager.Login(login);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                var updateUser = await _userManager.UpdateUser(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
