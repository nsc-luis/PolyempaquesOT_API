using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenDeTrabajoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrdenDeTrabajoController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var odt = _context.OrdenDeTrabajo;
                return Ok(odt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] OrdenDeTrabajo odt)
        {
            try
            {
                _context.OrdenDeTrabajo.Add(odt);
                _context.SaveChanges();
                return Ok(odt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idOrdenDeTrabajo}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] OrdenDeTrabajo odt, int idOrdenDeTrabajo)
        {
            try
            {
                var orden = _context.OrdenDeTrabajo.FirstOrDefault(o => o.idOrdenDeTrabajo == idOrdenDeTrabajo);
                orden.cantidad = odt.cantidad;
                orden.idProducto = odt.idProducto;
                orden.fechaOrden = odt.fechaOrden;
                orden.fechaCompromiso = odt.fechaCompromiso;
                orden.idCliente = odt.idCliente;
                orden.idEstatus = odt.idEstatus;
                _context.OrdenDeTrabajo.Update(orden);
                _context.SaveChanges();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idOrdenDeTrabajo}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idOrdenDeTrabajo)
        {
            try
            {
                var odt = _context.OrdenDeTrabajo.FirstOrDefault(o => o.idOrdenDeTrabajo == idOrdenDeTrabajo);
                _context.OrdenDeTrabajo.Remove(odt);
                _context.SaveChanges();
                return Ok(odt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
