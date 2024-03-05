using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OperadorController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var operadores = (from o in _context.Operador
                          join t in _context.Turno on o.idTurno equals t.idTurno
                          select new
                          {
                              t.idTurno,
                              turno = t.nombre,
                              o.idOperador,
                              o.nombre
                          });
                return Ok(operadores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Operador op)
        {
            try
            {
                _context.Operador.Add(op);
                _context.SaveChanges();
                return Ok(op);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idOperador}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Operador op, int idOperador)
        {
            try
            {
                var operador = _context.Operador.FirstOrDefault(o => o.idOperador == idOperador);
                operador.idTurno = op.idTurno;
                operador.nombre = op.nombre;
                _context.Operador.Update(operador);
                _context.SaveChanges();
                return Ok(operador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idOperador}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idOperador)
        {
            try
            {
                var op = _context.Operador.FirstOrDefault(o => o.idOperador == idOperador);
                _context.Operador.Remove(op);
                _context.SaveChanges();
                return Ok(op);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
