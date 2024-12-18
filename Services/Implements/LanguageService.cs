using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            var language = _mapper.Map<Language>(dto);
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LanguageDeleteDto language)
        {
            var entity = await _context.Languages.FirstOrDefaultAsync(l => l.Code == language.Code);
            if (entity == null)
            {
                throw new Exception("entity is null !!!");
            }

            _context.Languages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var items = await _context.Languages.ToListAsync();
            if (items is null)
            {
                throw new Exception("Items is null");
            }
            throw new Exception("Success!");
        }
        public async Task UpdateAsync(string code, LanguageUpdateDto language)
        {
            var entitiy = _context.Languages.Find(code);
            if (entitiy is null)
            {
                throw new ArgumentNullException();
            }
            var originalCode = entitiy.Code;
            originalCode = language.Code;
            entitiy.Name = language.Name;
            entitiy.Icon = language.IconUrl;
            await _context.SaveChangesAsync();
        }

    }
}
