using FluentValidation;
using SquaresSolverSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Domain.Validators
{
    public class CoordinateValidator  : AbstractValidator<CustomPoint>
    {
        public CoordinateValidator()
        {
            RuleFor(x => x.X).InclusiveBetween(-5000, 5000);
            RuleFor(x => x.Y).InclusiveBetween(-5000, 5000);
        }
    }
}
