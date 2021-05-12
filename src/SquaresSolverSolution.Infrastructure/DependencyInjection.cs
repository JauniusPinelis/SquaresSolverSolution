using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquaresSolverSolution.Domain.Interfaces;
using SquaresSolverSolution.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(c => c.UseSqlServer(defaultConnection));

            services.AddScoped<IPointsRepository, PointsRepository>();
        }
    }
}
