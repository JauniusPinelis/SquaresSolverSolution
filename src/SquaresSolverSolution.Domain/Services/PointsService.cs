using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Exceptions;
using SquaresSolverSolution.Domain.Helpers;
using SquaresSolverSolution.Domain.Interfaces;
using SquaresSolverSolution.Domain.Validators;
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

        public async Task AddPointAsync(CustomPoint point)
        {
            // first validate the point
            var validator = new CoordinateValidator();

            var validationResult = await validator.ValidateAsync(point);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(
                    ValidationHelpers.GenerateErrorMessage(validationResult.Errors)
                );
            }

            await _repository.AddPoint(point);
        }
    }
}
