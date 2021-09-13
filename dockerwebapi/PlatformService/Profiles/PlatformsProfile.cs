using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Profiles
{
    public class PlatformsProfile :Profile
    {
        public PlatformsProfile()
        {
            //Source(Model)   -> Target(Dtos)
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<PlatformReadDto,PlatformPublishedDto>();
            CreateMap<Platform,GrpcPlatformModel>()
            .ForMember(destinationMember=>destinationMember.PlatformId,Opt => Opt.MapFrom(src=>src.Id))
            .ForMember(destinationMember=>destinationMember.Name,Opt => Opt.MapFrom(src=>src.name))
            .ForMember(destinationMember=>destinationMember.Publisher,Opt => Opt.MapFrom(src=>src.Publisher));
        }
    }
}
