using AspCoreDependencyInjectionExtension.InjectionProperty;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreDependencyInjectionExtension.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [InjectionPropertyFilter]
    public class TestController : ControllerBase
    {
        [InjectionService]
        private ILogger<TestController> _logger { get; set; }

        public TestController()
        {
        }

        [HttpGet]
        public IActionResult Test()
        {
            _logger.LogInformation("Test Injection");

            return Ok();
        }
       
    }
}