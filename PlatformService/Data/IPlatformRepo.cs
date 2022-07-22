using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformsById(int id);
    void CreatePlatform(Platform platform);
}
