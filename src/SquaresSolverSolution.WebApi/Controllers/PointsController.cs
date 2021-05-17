using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Exceptions;
using SquaresSolverSolution.Domain.Interfaces;
using SquaresSolverSolution.Domain.Services;
using SquaresSolverSolution.Domain.Validators;
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
        private readonly IPointsRepository _repository;
        private readonly PointsService _service;

        public PointsController(IPointsRepository repository, PointsService service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomPoint>>> GetAll()
        {
            var points = await _repository.GetAll();

            return Ok(points);
        }

        [HttpPost]
        public async Task<ActionResult> AddPoint(CustomPoint point)
        {
            try
            {
                await _service.AddPoint(point);
            }
            catch (DbUpdateException)
            {
                return BadRequest("The point already exists");
            }
            catch(CustomValidationException ex)
            {
                return BadRequest(ex.Message);
            }
           
            return NoContent();
        }
    }
}
