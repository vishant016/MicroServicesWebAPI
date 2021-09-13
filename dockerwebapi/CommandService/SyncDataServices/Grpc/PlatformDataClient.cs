using System;
using System.Collections.Generic;
using AutoMapper;
using CommandService.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using PlatformService;

namespace CommandService.SyncDataServices.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PlatformDataClient(IConfiguration configuration,IMapper mapper)
        {
            _configuration=configuration;
            _mapper=mapper;     
        }
        public IEnumerable<Platform> ReturnAllPlatforms()
        {
            Console.WriteLine($"--> Calling Grpc Service {_configuration["GrpcPlatform"]}");
            var  channel=GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
            var client=new GrpcPlatform.GrpcPlatformClient(channel);
            var request=new GetAllRequest();

            try{
                    var repy=client.GetAllPlatforms(request);
                    return _mapper.Map<IEnumerable<Platform>>(repy.Platform);
            }catch(Exception ex){
                Console.WriteLine($"--> Couldnot call GRPC Serveer {ex.Message}");
                return null;
            }
        }
    }
}