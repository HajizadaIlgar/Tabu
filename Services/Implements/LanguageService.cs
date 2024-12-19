using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entities;
using Tabu.Exceptions.Language;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            var language = _mapper.Map<Language>(dto);
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LanguageDeleteDto language)
        {
            var entity = await _context.Languages.FirstOrDefaultAsync(l => l.Code == language.Code);
            if (entity == null)
                throw new LanguageNotFoundException();

            _context.Languages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var items = await _context.Languages.ToListAsync();
            if (items is null)
                throw new Exception("Items is null");

            return _mapper.Map<IEnumerable<LanguageGetDto>>(items);
        }
        public async Task UpdateAsync(string code, LanguageUpdateDto language)
        {
            var entitiy = _context.Languages.Find(code);
            if (entitiy is null)
                throw new LanguageNotFoundException();
            entitiy.Name = language.Name;
            entitiy.Icon = language.IconUrl;
            await _context.SaveChangesAsync();
        }
        async Task<Language?> _getByCode(string code)
            => await _context.Languages.FindAsync(code);


    }
}
