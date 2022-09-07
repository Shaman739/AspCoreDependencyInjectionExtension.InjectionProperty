# AspCoreDependencyInjectionExtension.InjectionProperty

# How to use.

You need to add attribute **[InjectionPropertyFilter]** to a controller.

```C#
    [InjectionPropertyFilter]
    public class TestController : ControllerBase
    {
```
And then you need to add attribute **[InjectionService]** to a property

```C#
        [InjectionService]
        private ILogger<TestController> _logger { get; set; }
```   

Attribute **[InjectionService]** can inject to public, protected or pricate property.

All example:
```C#
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
            //_logger is not null here
            _logger.LogInformation("Test Injection");

            return Ok();
        }
       
    }
```
