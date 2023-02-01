using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDBContext db;

        public UserController(UserDBContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await this.db.Users.ToListAsync();
        }

        [HttpGet("[action]/{Id}")]

        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.ID == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }
    }
}
