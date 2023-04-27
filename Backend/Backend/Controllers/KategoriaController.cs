using Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [EnableCors]
    [Route("api/kategoria")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {

        ReceptkonyvContext _context;

        public KategoriaController(ReceptkonyvContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Kategorium>>> Get()
        {
            var kategoriak = await _context.Kategoria.ToListAsync();
            if (kategoriak.IsNullOrEmpty())
                return BadRequest("Nincs kategória;");
            return Ok(kategoriak);
        }
    }
}
