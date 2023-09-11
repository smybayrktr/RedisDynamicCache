using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers;


[ApiController]
[Route("/api/v1/redis")]
public class RedisController : Controller
{

    private readonly ICacheService _cacheService;

    public RedisController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpGet("{key}")]
    public async Task<string> GetDataAsync(string key)
    {
        return await _cacheService.GetDataAsync(key);
    }

    [HttpPost]
    public async Task SetDataAsync(string key, object value)
    {
        await _cacheService.SetDataAsync(key, value);

    }
    [HttpDelete("{key}")]
    public async Task RemoveDataAsync(string key)
    {
        await _cacheService.RemoveDataAsync(key);
    }

}

