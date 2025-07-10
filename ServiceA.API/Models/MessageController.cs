using Microsoft.AspNetCore.Mvc;

namespace ServiceA.API.Models;

[ApiController]
[Route("api/[controller]")]
public class MessageController(IHttpClientFactory httpClientFactory, ILogger<MessageController> logger)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] MessageRequest request)
    {
        logger.LogInformation("ServiceA received message: {Message}", request.Content);

        var client = httpClientFactory.CreateClient();
        logger.LogInformation("ServiceA Created Client: {Message}", request.Content);

        // ⚠️ Use actual port for ServiceB.API
        logger.LogInformation("ServiceA Sent Request to ServiceB message: {request}", request);
        var response = await client.PostAsJsonAsync("http://serviceb.api:5002/api/echo", request);

        var result = await response.Content.ReadAsStringAsync();
        logger.LogInformation("ServiceB Returned message: {result}", result);
        return Ok(new { Forwarded = true, Response = result });
    }
}