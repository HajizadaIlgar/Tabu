using AutoMapper;
using Tabu.DTOs.BannedWords;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class BannedWordProfile : Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWord, BannedWordGetDto>();
            CreateMap<BannedWordCreateDto, BannedWord>();
        }
    }
}
