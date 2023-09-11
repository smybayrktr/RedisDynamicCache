using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Services;

public class CacheService: ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<string> GetDataAsync(string key)
    {
        var value = await _distributedCache.GetStringAsync(key);
        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }

        return null;
    }
    
    public async Task SetDataAsync(string key, object value)
    {
        try
        {
            string stringValue = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, stringValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
    }
   
    public async Task RemoveDataAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }
}

