using Microsoft.EntityFrameworkCore;
using PolyempaquesOT_API.Models;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PolyempaquesOT_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Cliente> Cliente { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Maquina> Maquina { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EstatusProceso> EstatusProceso { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Movimiento> Movimiento { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Operador> Operador { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OrdenDeTrabajo> OrdenDeTrabajo { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Producto> Producto { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<TipoProducto> TipoProducto { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Turno> Turno { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
    }
}
