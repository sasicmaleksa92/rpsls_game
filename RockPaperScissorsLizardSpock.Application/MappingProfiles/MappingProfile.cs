using AutoMapper;
using RockPaperScissorsLizardSpock.Application.Dtos;
using RockPaperScissorsLizardSpock.Domain.Entities;
using RockPaperScissorsLizardSpock.Domain.Enums;
using RockPaperScissorsLizardSpock.Domain.Extensions;

namespace RockPaperScissorsLizardSpock.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<GameChoice, GameChoiceDto>().ReverseMap();
            CreateMap<GameResultDto, GameResult>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result.ToEnum<GameResultsEnum>()));
            CreateMap<GameResult, GameResultDto>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.GamePlayer.UserName))
                .ForMember(dest => dest.PlayerChoiceName, opt => opt.MapFrom(src => src.PlayerChoice.Name))
                .ForMember(dest => dest.ComputerChoiceName, opt => opt.MapFrom(src => src.ComputerChoice.Name))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result.ToString()));


        }
    }
}