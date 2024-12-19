using Tabu.DTOs.Games;

namespace Tabu.Services.Abstracts
{
    public interface IGameService
    {

        Task<IEnumerable<GameGetDto>> GetAllAsync();
        Task DeleteAsync(GameDeleteDto dbo);
        Task CreateAsync(GameCreateDto dto);
        Task UpdateAsync(string code, GameUpdateDto dbo);
    }
}
