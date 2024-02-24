using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Operador
    {
        [Key]
        public int idOperador { get; set; }
        public string? nombre { get; set; }
        public int idTurno { get; set; }
    }
}
