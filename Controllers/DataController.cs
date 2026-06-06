using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApiAzureAppService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly ExternalApiOptions _apiOptions;
    private readonly IConfiguration _config;

    public DataController(
        IOptions<ExternalApiOptions> apiOptions,
        IConfiguration config)
    {
        _apiOptions = apiOptions.Value;
        _config = config;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // var connectionString = _config["ConnectionStrings:DefaultConnection"];

        return Ok(new { status = "ok", hasApiKey = !string.IsNullOrEmpty(_apiOptions.ApiKey) });
    }
}