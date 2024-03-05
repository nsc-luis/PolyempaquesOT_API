using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string? nombre { get; set; }
        public string? observacion { get; set; }
    }
}
