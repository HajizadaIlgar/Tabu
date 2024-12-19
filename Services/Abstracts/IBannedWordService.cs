using Tabu.DTOs.BannedWords;

namespace Tabu.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task DeleteAsync(BannedWordDeleteDto dto);
        Task CreateAsync(BannedWordCreateDto dto);
        Task UpdateAsync(string code, BannedWordUpdateDto language);
    }
}
