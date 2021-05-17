using Microsoft.EntityFrameworkCore;
using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Infrastructure.Repositories
{
    public class PointsRepository : IPointsRepository
    {
        private readonly DataContext _context;

        public PointsRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddPoint(CustomPoint point)
        {
            _context.Add(point);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomPoint>> GetAll()
        {
            var points = await _context.Points.ToListAsync();

            return points;
        }
    }
}
