using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SquaresSolverSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextFileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostFormData([FromForm] IFormFile file)
        {
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var content = await sr.ReadToEndAsync();
                return Ok(content);
            }
        }
    }
}
