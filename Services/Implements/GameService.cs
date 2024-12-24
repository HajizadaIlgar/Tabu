using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Exceptions;
using Tabu.ExternalServices.Abstracts;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class GameService(ICacheService _cache, TabuDbContext _context, IMapper _mapper) : IGameService
    {
        public async Task<Guid> AddAsync(GameCreateDto dto)
        {
            var datas = _mapper.Map<Game>(dto);
            await _context.AddAsync(datas);
            await _context.SaveChangesAsync();
            return datas.Id;
        }

        public async Task EndAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetCurrentStatus(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null)
                throw new EntityNullReferenceException();
            return entity;
        }

        public async Task<WordForGameDto> PassAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            if (status.Pass < status.MaxPassCount)
            {
                status.Pass++;
                var currentWord = status.Words.Pop();
                await _cache.SetAsync(id.ToString(), status);
                return currentWord;
            }
            return null;
        }
        public async Task<WordForGameDto> StartAsync(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null)
                throw new EntityNullReferenceException();
            var words = await _context.Words.Where(x => x.LanguageCode == entity.LanguageCode)
                .Take(10)
                .Select(x => new WordForGameDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    BannedWords = x.BannedWords.Select(y => y.Text).Take((int)entity.Levels).ToList(),
                }).ToListAsync();
            GameStatusDto status = new GameStatusDto
            {
                Pass = 0,
                Success = 0,
                Wrong = 0,
                Words = new Stack<WordForGameDto>(words),
                UsedWordsIds = words.Select(x => x.Id).ToList(),
                LangCode = entity.LanguageCode,
                MaxPassCount = (byte)entity.SkipCount,
            };
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status);
            return word;
        }
        public async Task<WordForGameDto> SuccesAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Success++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status);
            return word;
        }

        public async Task<WordForGameDto> WrongAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Wrong++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status);
            return word;
        }
        async Task<GameStatusDto> _getGameStatusAsync(Guid id)
        {
            GameStatusDto status = await _cache.GetAsync<GameStatusDto>(id.ToString());
            if (status is null)
                throw new EntityNullReferenceException();
            return status;
        }
        async Task _addNewWords(GameStatusDto status)
        {
            if (status.Words.Count < 6)
            {
                var newWords = await _context.Words.Where(x => x.LanguageCode == status.LangCode && !status.UsedWordsIds
                    .Contains(x.Id))
                    .Take(10)
                    .Select(x => new WordForGameDto
                    {
                        Id = x.Id,
                        Text = x.Text,
                        BannedWords = x.BannedWords
                        .Select(z => z.Text).ToList()
                    }).ToListAsync();
                status.UsedWordsIds.AddRange(newWords.Select(x => x.Id));
                newWords.ForEach(x => status.Words.Push(x));
            }
        }
    }
}
