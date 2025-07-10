using Microsoft.AspNetCore.Mvc;

namespace ServiceB.API.Models;

[ApiController]
[Route("api/[controller]")]
public class EchoController : ControllerBase
{
    private readonly ILogger<EchoController> _logger;

    public EchoController(ILogger<EchoController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Echo([FromBody] MessageRequest request)
    {
        _logger.LogInformation("ServiceB.API received message: {Message}", request.Content);
        return Ok($"Echoed: {request.Content}");
    }
}