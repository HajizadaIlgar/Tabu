using Tabu.DTOs.Words;

namespace Tabu.Services.Abstracts
{
    public interface IWordService
    {
        Task<int> CreateAsync(WordCreateDto dto);
        Task UpdateAsync(int id, WordUpdateDto dto);
        Task DeleteAsync(WordDeleteDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
    }
}
