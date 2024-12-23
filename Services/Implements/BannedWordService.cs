using Tabu.DTOs.BannedWords;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class BannedWordService : IBannedWordService
    {
        public Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
