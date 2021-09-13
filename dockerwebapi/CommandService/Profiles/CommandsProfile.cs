using AutoMapper;
using CommandService.Dtos;
using CommandService.Models;
using PlatformService;

namespace CommandService.Profiles{
    public class CommandsProfile : Profile{
        public CommandsProfile()
        {
            
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<CommandCreateDto,Command>();
            CreateMap<Command,CommandReadDto>();
            CreateMap<PlatformPublishedDto,Platform>()
            .ForMember(destinationMember=>destinationMember.ExternalID,
            memberOptions=>memberOptions.MapFrom(sourceMember=>sourceMember.Id));

            CreateMap<GrpcPlatformModel,Platform>()
            .ForMember(destinationMember=>destinationMember.ExternalID,memberOptions=>memberOptions.MapFrom(sourceMember=>sourceMember.PlatformId))
            .ForMember(destinationMember=>destinationMember.Name,memberOptions=>memberOptions.MapFrom(sourceMember=>sourceMember.Name))
            .ForMember(destinationMember=>destinationMember.Commands,memberOptions=>memberOptions.Ignore());
        }
    }
}