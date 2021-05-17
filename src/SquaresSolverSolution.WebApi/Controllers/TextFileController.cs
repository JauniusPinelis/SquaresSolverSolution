using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SquaresSolverSolution.Domain.Entities;
using SquaresSolverSolution.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SquaresSolverSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextFileController : ControllerBase
    {
        private readonly PointsService _service;

        public TextFileController(PointsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> PostFormData()
        {
            var files = Request.Form.Files;
            List<CustomPoint> receivedPoints = new(); 

            var result = new StringBuilder();
            foreach (var file in files)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                    {
                        var pointText = await reader.ReadLineAsync();

                        var pointsAsString = pointText.Split(" ").ToList();
                        if (pointsAsString.Count() == 2)
                        {
                            var newPoint = new CustomPoint();

                            newPoint.X = Int32.Parse(pointsAsString[0]);
                            newPoint.Y = Int32.Parse(pointsAsString[1]);

                            receivedPoints.Add(newPoint);
                        }

                    }
                        
                }

            }

            foreach(var receivedPoint in receivedPoints)
            {
                await _service.AddPointAsync(receivedPoint);
            }

            return Ok();
        }

       
    }
}
