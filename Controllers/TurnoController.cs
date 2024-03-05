using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TurnoController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var turnos = _context.Turno;
                return Ok(turnos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Turno turno)
        {
            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                return Ok(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idTurno}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Turno tur, int idTurno)
        {
            try
            {
                var turno = _context.Turno.FirstOrDefault(t => t.idTurno == idTurno);
                turno.nombre = tur.nombre;
                _context.Turno.Update(turno);
                _context.SaveChanges();
                return Ok(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idTurno}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idTurno)
        {
            try
            {
                var turno = _context.Turno.FirstOrDefault(t => t.idTurno == idTurno);
                _context.Turno.Remove(turno);
                _context.SaveChanges();
                return Ok(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
