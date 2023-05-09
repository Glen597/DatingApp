using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // to access it we will then use ../api/users(le debut du nom  de notre classe UsersController)
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }
        [HttpGet("{Id}")]
        public Async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var user = _context.Users.FindAsync(id);
            return user;
        }

       

    }
}