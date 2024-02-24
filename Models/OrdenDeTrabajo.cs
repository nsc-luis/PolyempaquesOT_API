using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class OrdenDeTrabajo
    {
        [Key]
        public int idOrdenDeTrabajo { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        [Precision(10, 2)]
        public  decimal cantidad { get; set; }
        public DateOnly fechaOrden { get; set; }
        public DateOnly? fechaCompromiso { get; set; }
        public int idEstatus { get; set; }
    }
}
