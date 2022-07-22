using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPrlatforms();
    Platform GetPrlatformsById(int id);
    void CreatePlatform(Platform platform);
}
