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
    }
}
