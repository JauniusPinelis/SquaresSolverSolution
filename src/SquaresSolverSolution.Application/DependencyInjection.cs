using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquaresSolverSolution.Domain;
using SquaresSolverSolution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDomainServices();
            services.RegisterDataContext(configuration);
        }
    }
}
