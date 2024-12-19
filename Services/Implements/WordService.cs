using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Words;
using Tabu.Entities;
using Tabu.Exceptions.Word;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class WordService(TabuDbContext _context, IMapper _mapper) : IWordService
    {
        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.LanguageCode == dto.Language))
                throw new Exception();
            if (dto.BannedWords.Count() != 8)
                throw new InvalidBannedWordCountException();
            //var language = _mapper.Map<Word>(dto);
            Word word = new Word
            {
                LanguageCode = dto.Language,
                Text = dto.Text,
                BannedWords = dto.BannedWords.Select(x => new BannedWord { Text = x }).ToList()
            };
            await _context.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var data = await _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(data);
        }



        public async Task DeleteAsync(int id)
        {
            var data = await _context.Words.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            _context.Words.Remove(data);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, WordUpdateDto dto)
        {
            var entitiy = await _context.Words.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entitiy is null)
                throw new NullReferenceException();
            entitiy.Text = dto.Text;
            entitiy.LanguageCode = dto.Language;
            entitiy.Id = id;
            await _context.SaveChangesAsync();

        }

        public Task DeleteAsync(int id, WordDeleteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(WordDeleteDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
