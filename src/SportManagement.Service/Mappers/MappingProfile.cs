using AutoMapper;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Matches;
using SportManagement.Service.DTOs.Players;
using SportManagement.Service.DTOs.Scores;
using SportManagement.Service.DTOs.Teams;
using SportManagement.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.Mappers
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Match, MatchForCreationDto>().ReverseMap();
            CreateMap<Match, MatchForUpdateDto>().ReverseMap();
            CreateMap<Match, MatchForResultDto>().ReverseMap();

            CreateMap<Player, PlayerForCreationDto>().ReverseMap();
            CreateMap<Player, PlayerForUpdateDto>().ReverseMap();
            CreateMap<Player, PlayerForResultDto>().ReverseMap();

            CreateMap<Score, ScoreForCreationDto>().ReverseMap();
            CreateMap<Score, ScoreForUpdateDto>().ReverseMap();
            CreateMap<Score, ScoreForResultDto>().ReverseMap();

            CreateMap<Team, TeamForCreationDto>().ReverseMap();
            CreateMap<Team, TeamForUpdateDto>().ReverseMap();
            CreateMap<Team, TeamForResultDto>().ReverseMap();

            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<UserForCreationDto, User>().ReverseMap();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
        }
    }
}
