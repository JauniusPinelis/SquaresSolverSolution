using Microsoft.Extensions.DependencyInjection;
using SquaresSolverSolution.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<PointsService>();
            
        }
    }
}
