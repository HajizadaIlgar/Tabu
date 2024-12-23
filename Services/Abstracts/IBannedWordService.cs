using Tabu.DTOs.BannedWords;

namespace Tabu.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
    }
}
