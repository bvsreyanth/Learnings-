using Concrete_classUsingDI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Concrete_classUsingDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly Car _car;

        public TransportController(Car car)
        {
            _car = car;
        }

        [HttpGet("use-transport")]
        public IActionResult UseTransport()
        {
            Bicycle bicycle = new Bicycle();
            return Ok(bicycle.Ride());
        }
    }
}

