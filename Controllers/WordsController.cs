using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Words;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(WordCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, WordUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
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
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _service.DeleteAsync(id);
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
}
