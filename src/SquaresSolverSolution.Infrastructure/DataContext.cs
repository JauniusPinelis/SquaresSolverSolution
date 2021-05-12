using Microsoft.EntityFrameworkCore;
using SquaresSolverSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomPoint>()
                .HasKey(c => new { c.X, c.Y });
        }

        public DbSet<CustomPoint> Points { get; set; }
    }
}
