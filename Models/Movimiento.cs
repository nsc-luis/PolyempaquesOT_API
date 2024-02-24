using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Movimiento
    {
        [Key]
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        [Precision(10, 2)]
        public decimal peso { get; set; }
        public int idOperador { get; set; }
        public string? folioExtrusion { get; set; }
        public int idTurno { get; set; }
        public int idMaquina { get; set; }
        public int idOrdenDeTrabajo { get; set; }
    }
}
