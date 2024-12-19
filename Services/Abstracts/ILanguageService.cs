using Tabu.DTOs.Languages;

namespace Tabu.Services.Abstracts
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task DeleteAsync(LanguageDeleteDto language);
        Task CreateAsync(LanguageCreateDto dto);
        Task UpdateAsync(string code, LanguageUpdateDto language);
    }
}
