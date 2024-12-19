using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _service.GetAllAsync();
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
        try
        {
            await _service.UpdateAsync(code, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
    [HttpDelete]
    [Route("{code}")]
    public async Task<IActionResult> Delete(string code, LanguageDeleteDto getdto)
    {
        try
        {
            await _service.DeleteAsync(getdto);
            return NoContent();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = ex.Message
                });
            }
        }
    }
}
