using System;
using System.Text.Json;
using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;


        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);
            switch (eventType)
            {
                case EventType.PlatformPublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("-->Determine Event");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("-->Platform Published Event Detached");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("-->Could not determine the EventType");
                    return EventType.Undetermined;
            }
        }

        private void addPlatform(string PlatformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
                var PlatformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(PlatformPublishedMessage);
                try
                {
                        var plat=_mapper.Map<Platform>(PlatformPublishedDto);
                        if(!repo.ExternalPlatformExist(plat.ExternalID)){
                               repo.CreatePlatform(plat);
                               repo.SaveChanges(); 
                               Console.WriteLine("-->Platform Added");
                        }else{
                            Console.WriteLine("--> Platform Already Exists");
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"-->could not add Platform to Db{ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}