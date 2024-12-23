using Microsoft.AspNetCore.Mvc;
using Tabu.ExternalServices.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(ICacheService _cache) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _cache.GetAsync<string>(key));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Set(string key, string value)
        {
            await _cache.SetAsync(key, value, 10);
            return Ok();
        }
    }
}
