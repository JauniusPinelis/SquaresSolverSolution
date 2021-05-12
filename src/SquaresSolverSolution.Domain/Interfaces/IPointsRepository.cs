using SquaresSolverSolution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Domain.Interfaces
{
    public interface IPointsRepository
    {
        Task<IEnumerable<CustomPoint>> GetAll();
    }
}