using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class Turno
    {
        [Key]
        public int idTurno { get; set; }
        public string? nombre { get; set; }
    }
}
