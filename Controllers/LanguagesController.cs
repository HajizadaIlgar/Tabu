using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = _service.GetAllAsync();
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpPut]
    [Route("{code}")]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        var dats = _service.UpdateAsync(code, dto);
        return Ok(dats);
    }

    [HttpDelete]
    [Route("{code}")]
    public async Task<IActionResult> Delete(string code, LanguageDeleteDto getdto)
    {
        await _service.DeleteAsync(getdto);
        return Content("Success");
    }
}
