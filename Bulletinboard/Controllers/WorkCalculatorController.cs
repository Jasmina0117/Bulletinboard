using Bulletinboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bulletinboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkCalculatorController : Controller
    {
        private readonly IWorkCalculatorService _service;

        public WorkCalculatorController(IWorkCalculatorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<double> Get(double price, double hourlyWage)
        {
            try
            {
                var hours = _service.CalculateHours(price, hourlyWage);
                return Ok(hours);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
