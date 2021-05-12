using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Domain.Services
{
    public class PointsService
    {
        private IPointsRepository _repository;

        public PointsService(IPointsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<CustomPoint>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
