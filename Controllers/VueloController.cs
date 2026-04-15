    using ApiVuelos.Data;
    using ApiVuelos.Models;
    using global::ApiVuelos.Data;
    using global::ApiVuelos.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace ApiVuelos.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class VueloController : ControllerBase
        {
            private readonly AppDbContext _context;

            public VueloController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelos()
            {
                return await _context.Vuelos.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Vuelo>> GetVuelo(int id)
            {
                var vuelo = await _context.Vuelos.FindAsync(id);

                if (vuelo == null)
                    return NotFound();

                return vuelo;
            }

            [HttpPost]
            public async Task<ActionResult<Vuelo>> PostVuelo(Vuelo vuelo)
            {
                _context.Vuelos.Add(vuelo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVuelo), new { id = vuelo.id_vuelo }, vuelo);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutVuelo(int id, Vuelo vuelo)
            {
                if (id != vuelo.id_vuelo)
                    return BadRequest();

                _context.Entry(vuelo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteVuelo(int id)
            {
                var vuelo = await _context.Vuelos.FindAsync(id);

                if (vuelo == null)
                    return NotFound();

                _context.Vuelos.Remove(vuelo);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }