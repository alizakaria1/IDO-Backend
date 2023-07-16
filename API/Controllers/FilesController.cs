using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.UserStore;
using System.Security.Claims;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private UserManager _userManager;
        private StoreContext _context;
        public FilesController(UserManager userManager, StoreContext context)
        {
            _userManager= userManager;
            _context= context;
        }
        [Route("UploadFile")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
           using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var path = Directory.GetCurrentDirectory();
                var fileExtension = Path.GetExtension(file.FileName);

                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                var fullPath = string.Format(@"{0}{1}{2}", path, "\\Files\\Images\\", fileName);

                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var user = await _context.User.Where(x => x.UserId == userId).SingleOrDefaultAsync();

                user.Image = fullPath;

                var retrievedUser = await _userManager.UpdateUser(user);

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }

                scope.Complete();

                return Ok();
            }
        }
    }
}
