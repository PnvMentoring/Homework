using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFcore.Models;
using EFcore.Data;

namespace EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController(EfcoreContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return await context.Characters.Include(c => c.Game).ToListAsync();
        }
    }
}