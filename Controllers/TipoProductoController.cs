using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TipoProductoController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var tiposProducto = _context.TipoProducto;
                return Ok(tiposProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] TipoProducto tp)
        {
            try
            {
                _context.TipoProducto.Add(tp);
                _context.SaveChanges();
                return Ok(tp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idTipoProducto}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] TipoProducto tp, int idTipoProducto)
        {
            try
            {
                var tipoProducto = _context.TipoProducto.FirstOrDefault(m => m.idTipoProducto == idTipoProducto);
                tipoProducto.nombre = tp.nombre;
                _context.TipoProducto.Update(tipoProducto);
                _context.SaveChanges();
                return Ok(tipoProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idTipoProducto}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idTipoProducto)
        {
            try
            {
                var tp = _context.TipoProducto.FirstOrDefault(m => m.idTipoProducto == idTipoProducto);
                _context.TipoProducto.Remove(tp);
                _context.SaveChanges();
                return Ok(tp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
