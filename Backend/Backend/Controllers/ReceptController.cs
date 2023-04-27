using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [EnableCors]
    [Route("api/recept")]
    [ApiController]
    public class ReceptController : ControllerBase
    {
        ReceptkonyvContext _context;

        public ReceptController(ReceptkonyvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recept>>> Get()
        {

            var receptek = await _context.Recepts.Include(x => x.Kat).ToListAsync();
            if(receptek.IsNullOrEmpty())
                return BadRequest("Nincs recept");
            return Ok(receptek);
        }

        [HttpPost]
        public async Task<ActionResult<List<Recept>>> AddRecept(Recept recept)
        {
            _context.Recepts.AddAsync(recept);
            _context.SaveChangesAsync();
            return Ok( await _context.Recepts.Include(x=> x.Kat).ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var recept = await _context.Recepts.FindAsync(id);
            if(recept ==  null)
                return BadRequest("Nem létezik az adott recept.");
            _context.Recepts.Remove(recept);
            await _context.SaveChangesAsync();
            return Ok("Siker");
        }

    }
}
