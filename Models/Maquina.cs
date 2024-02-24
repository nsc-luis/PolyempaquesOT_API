using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Maquina
    {
        [Key]
        public int idMaquina { get; set; }
        public string? nombre { get; set; }
        public bool estatus { get; set; }
    }
}
