using System;
using System.Collections.Generic;
using CommandService.Models;
using CommandService.SyncDataServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CommandService.Data
{
    public static class PrepDb{
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                    var grpcClient=serviceScope.ServiceProvider.GetService<IPlatformDataClient>();
                    var platforms=grpcClient.ReturnAllPlatforms();
                    SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(),platforms);
            }
        }

        private static void SeedData(ICommandRepo repo,IEnumerable<Platform> platforms){
                    Console.WriteLine("-->Seeding new platforms...");
                    foreach (var plat in platforms)
                    {
                        if(!repo.ExternalPlatformExist(plat.ExternalID)){
                            repo.CreatePlatform(plat);
                        }
                        repo.SaveChanges();
                    }
        }
    }
}