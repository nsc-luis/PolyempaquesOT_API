using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MaquinaController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var maquinas = _context.Maquina;
                return Ok(maquinas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Maquina maq)
        {
            try
            {
                _context.Maquina.Add(maq);
                _context.SaveChanges();
                return Ok(maq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idMaquina}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Maquina maq, int idMaquina)
        {
            try
            {
                var maquina = _context.Maquina.FirstOrDefault(m => m.idMaquina == idMaquina);
                maquina.nombre = maq.nombre;
                maquina.estatus = maq.estatus;
                _context.Maquina.Update(maq);
                _context.SaveChanges();
                return Ok(maquina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idMaquina}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idMaquina)
        {
            try
            {
                var maq = _context.Maquina.FirstOrDefault(m => m.idMaquina == idMaquina);
                _context.Maquina.Remove(maq);
                _context.SaveChanges();
                return Ok(maq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
