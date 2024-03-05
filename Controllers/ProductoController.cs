using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PolyempaquesOT_API.Models;

namespace PolyempaquesOT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductoController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                var productos= (from p in _context.Producto
                                join tp in _context.TipoProducto on p.idTipo equals tp.idTipoProducto
                                select new {
                                    p.idProducto,
                                    p.nombre,
                                    p.bar,
                                    p.presentacion,
                                    p.medida,
                                    p.precio,
                                    p.calibre,
                                    p.color,
                                    p.densidad,
                                    p.idTipo,
                                    p.tratado,
                                    p.aditivo,
                                    tp.idTipoProducto,
                                    tipoProducto = tp.nombre,
                                }).ToList();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idProducto}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put([FromBody] Producto prod, int idProducto)
        {
            try
            {
                var producto = _context.Producto.FirstOrDefault(p => p.idProducto == idProducto);
                producto.precio = prod.precio;
                producto.bar = prod.bar;
                producto.nombre = prod.nombre;
                prod.medida = prod.medida;
                prod.presentacion = prod.presentacion;
                prod.calibre = prod.calibre;
                prod.densidad = prod.densidad;
                prod.aditivo = prod.aditivo;
                prod.color = prod.color;
                producto.idTipo = prod.idTipo;
                producto.medida = producto.medida;
                producto.tratado = prod.tratado;
                _context.Producto.Update(producto);
                _context.SaveChanges();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idProducto}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(int idProducto)
        {
            try
            {
                var producto = _context.Producto.FirstOrDefault(p => p.idProducto == idProducto);
                _context.Producto.Remove(producto);
                _context.SaveChanges();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
