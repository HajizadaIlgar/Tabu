using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Games;
using Tabu.ExternalServices.Abstracts;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(ICacheService _cache, IGameService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            return Ok(await _service.AddAsync(dto));
        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Start(Guid id)
        {
            await _service.StartAsync(id);
            return Ok();
        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Success(Guid id)
        {
            await _service.SuccesAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetGameData(Guid id)
        {
            return Ok(await _service.GetCurrentStatus(id));
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCache(string key)
        {
            await _cache.Remove<string>(key);
            return NoContent();
        }
    }
}
