using AutoMapper;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>()
                 .ForMember(x => x.LanguageCode, y => y.MapFrom(z => z.Language));
            ;
            CreateMap<Word, WordGetDto>()
                .ForMember(x => x.Language, y => y.MapFrom(z => z.LanguageCode));
        }
    }
}
