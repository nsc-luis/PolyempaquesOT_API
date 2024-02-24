using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class TipoProducto
    {
        [Key]
        public int idTipoProducto { get; set; }
        public string? nombre { get; set; }
    }
}
