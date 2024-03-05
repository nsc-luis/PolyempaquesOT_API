using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovimientoController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var mov = _context.Movimiento;
                return Ok(mov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Movimiento mov)
        {
            try
            {
                _context.Movimiento.Add(mov);
                _context.SaveChanges();
                return Ok(mov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idMovimiento}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Movimiento mov, int idMovimiento)
        {
            try
            {
                var movimiento = _context.Movimiento.FirstOrDefault(m => m.idMovimiento == idMovimiento);
                movimiento.idTurno = mov.idTurno;
                movimiento.folioExtrusion = mov.folioExtrusion;
                movimiento.idProducto = mov.idProducto;
                movimiento.idMaquina = mov.idMaquina;
                movimiento.idOrdenDeTrabajo = mov.idOrdenDeTrabajo;
                movimiento.idOperador = mov.idOperador;
                movimiento.peso = mov.peso;
                _context.Movimiento.Update(movimiento);
                _context.SaveChanges();
                return Ok(movimiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idMovimiento}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idMovimiento)
        {
            try
            {
                var mov = _context.Movimiento.FirstOrDefault(m => m.idMovimiento == idMovimiento);
                _context.Movimiento.Remove(mov);
                _context.SaveChanges();
                return Ok(mov);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
