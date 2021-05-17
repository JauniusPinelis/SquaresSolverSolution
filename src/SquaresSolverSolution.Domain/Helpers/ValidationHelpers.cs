using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Domain.Helpers
{
    public static class ValidationHelpers
    {
        public static string GenerateErrorMessage(IEnumerable<ValidationFailure> validationFailures)
        {
            var errors = "";

            foreach (var error in validationFailures)
            {
                errors += error.ToString() + "\n";
            }

            return errors;
        }
    }
}
