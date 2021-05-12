using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Services;
using SquaresSolverSolution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsController : ControllerBase
    {
        private readonly PointsService _service;

        public PointsController(PointsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomPoint>>> GetAll()
        {
            var points = await _service.GetAll();

            return Ok(points);
        }
    }
}
