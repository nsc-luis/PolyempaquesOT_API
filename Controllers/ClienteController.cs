using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var clientes = _context.Cliente;
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Cliente cte)
        {
            try
            {
                _context.Cliente.Add(cte);
                _context.SaveChanges();
                return Ok(cte);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idCliente}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Cliente cliente, int idCliente)
        {
            try
            {
                var cte = _context.Cliente.FirstOrDefault(c => c.idCliente == idCliente);
                cte.nombre = cliente.nombre;
                _context.Cliente.Update(cte);
                _context.SaveChanges();
                return Ok(cte);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idCliente)
        {
            try
            {
                var cte = _context.Cliente.FirstOrDefault(c => c.idCliente == idCliente);
                _context.Cliente.Remove(cte);
                _context.SaveChanges();
                return Ok(cte);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
