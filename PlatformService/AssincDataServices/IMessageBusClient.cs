using PlatformService.Dtos;

namespace PlatformService.AssincDataServices;

public interface IMessageBusClient
{
    void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
}
