using TaskLand.API.DTO.Request;
using TaskLand.API.DTO.Response;

namespace TaskLand.API.Interfaces.Mappers
{
    public interface ITaskMapperService
    {
        ResponseTask ToDto(Entities.Task taskEntity);
        Entities.Task ToEntity(RequestTaskCreate taskDto);
        Entities.Task ToEntity(RequestTaskUpdate taskDto);
    }
}
