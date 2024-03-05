using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolyempaquesOT_API.Models
{
    public class OrdenDeCompra
    {
        [Key]
        public int idOrdenDeCompra { get; set; }
        public string? nombreCliente { get; set; }
        public string? descripcion { get; set; }
        public string? agenteVenta { get; set; }
        [NotMapped]
        public DateOnly fecha { get; set; }
    }
}
