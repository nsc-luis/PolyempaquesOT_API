using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string? nombre { get; set; }
        public int idTipo { get; set; }
        public string? color { get; set; }
        public string? medida { get; set; }
        [Precision(10, 2)]
        public decimal calibre { get; set; }
        public string? aditivo { get; set; }
        public string? bar { get; set; }
        public string? presentacion { get; set; }
        public string? tratado { get; set; }
        [Precision(10, 2)]
        public decimal precio { get; set; }
        public string? densidad { get; set; }
    }
}
