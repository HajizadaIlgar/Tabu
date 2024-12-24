using AutoMapper;
using Tabu.DTOs.Games;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Game>();
        }
    }
}
