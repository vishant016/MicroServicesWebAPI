
using System;
using System.Collections.Generic;
using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository,IMapper mapper)
        {
                _repository=repository;
                _mapper=mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms(){
            Console.WriteLine("-->Getting platform from CommandController");
            var platformItems=_repository.GetAllPlatform();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        




        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound Post # Command Service");
            return Ok("Inbound test from Platform Controlller");
        }
    }
}