using Newtonsoft.Json.Linq;

namespace Services;

public interface ICacheService
{
    Task<string> GetDataAsync(string key);
    Task SetDataAsync(string key, dynamic value);
    Task RemoveDataAsync(string key);
}

