using AutoMapper;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word, WordGetDto>()
                .ForMember(x => x.Language, y => y.MapFrom(lc => lc.LanguageCode))
                .ForMember(x => x.BannedWords, y => y.MapFrom(z => z.BannedWords.Select(bw => bw.Text).ToList()));
            CreateMap<string, BannedWord>();
        }
    }
}
