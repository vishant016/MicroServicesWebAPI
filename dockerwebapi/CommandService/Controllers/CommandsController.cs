using System;
using System.Collections.Generic;
using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase{
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId){
            Console.WriteLine($"--> Hit GetCommandsForPlatform : {platformId}");
            if(!_repository.PlatformExits(platformId)){
                return NotFound();
            }

            var Commands =_repository.GetCommandsForPlatform(platformId);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(Commands));
        }
        
        [HttpGet("{commandId}",Name ="GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId,int commandId){
             Console.WriteLine($"--> Hit GetCommandForPlatform : {platformId}/{commandId}");
            if(!_repository.PlatformExits(platformId)){
                return NotFound();

            }

            var command=_repository.GetCommand(platformId,commandId);
            if(command==null){
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId,CommandCreateDto commandCreateDto){
             Console.WriteLine($"--> Hit CreateCommandForPlatform : {platformId}");
            if(!_repository.PlatformExits(platformId)){
                Console.WriteLine("-->Not found");
                return NotFound();
            }
            var command=_mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(platformId,command);
            _repository.SaveChanges();

            var CommandReadDto=_mapper.Map<CommandReadDto>(command);
            return CreatedAtRoute(nameof(GetCommandForPlatform),new {platformId=platformId,commandId=CommandReadDto.Id},CommandReadDto);

        }


    }
}