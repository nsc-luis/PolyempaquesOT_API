using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeCompraController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdenDeCompraController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var ordenesDeCompra = _context.OrdenDeCompra;
                return Ok(ordenesDeCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] OrdenDeCompra ordenDeCompra)
        {
            try
            {
                _context.OrdenDeCompra.Add(ordenDeCompra);
                _context.SaveChanges();
                return Ok(ordenDeCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idOrdenDeCompra}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] OrdenDeCompra odt, int idOrdenDeCompra)
        {
            try
            {
                var ordenDeCompra = _context.OrdenDeCompra.FirstOrDefault(t => t.idOrdenDeCompra == idOrdenDeCompra);
                ordenDeCompra.descripcion = odt.descripcion;
                ordenDeCompra.agenteVenta = odt.agenteVenta;
                ordenDeCompra.nombreCliente = odt.nombreCliente;
                ordenDeCompra.fecha = odt.fecha;
                _context.OrdenDeCompra.Update(ordenDeCompra);
                _context.SaveChanges();
                return Ok(ordenDeCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idOrdenDeCompra}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idOrdenDeCompra)
        {
            try
            {
                var ordenDeCompra = _context.OrdenDeCompra.FirstOrDefault(odt => odt.idOrdenDeCompra == idOrdenDeCompra);
                _context.OrdenDeCompra.Remove(ordenDeCompra);
                _context.SaveChanges();
                return Ok(ordenDeCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
