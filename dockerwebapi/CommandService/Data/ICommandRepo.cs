using System.Collections.Generic;
using CommandService.Models;

namespace CommandService.Data{
    public interface ICommandRepo{
        bool SaveChanges();

        //platforms
        IEnumerable<Platform> GetAllPlatform();
        void CreatePlatform(Platform plat);
        bool PlatformExits(int platformId);
        bool ExternalPlatformExist(int ExternalPlatformId);

        //commands

        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int plaformId,int commandId);
        void CreateCommand(int platformId,Command command);
    }
}