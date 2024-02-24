using System.ComponentModel.DataAnnotations;

namespace PolyempaquesOT_API.Models
{
    public class EstatusProceso
    {
        [Key]
        public int idEstatus { get; set; }
        public string? nombre { get; set; }
    }
}
