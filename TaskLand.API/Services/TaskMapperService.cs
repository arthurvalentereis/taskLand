using TaskLand.API.DTO.Request;
using TaskLand.API.DTO.Response;
using TaskLand.API.Interfaces.Mappers;

namespace TaskLand.API.Services
{
    public class TaskMapperService : ITaskMapperService
    {
        public ResponseTask ToDto(Entities.Task taskEntity)
        {
            return new ResponseTask
            {
                Name = taskEntity.Name,
                Title = taskEntity.Title,
                Description = taskEntity.Description
            };
        }

        public Entities.Task ToEntity(RequestTaskCreate taskDto)
        {
            return new Entities.Task
            {
                Name = taskDto.Name,
                Title = taskDto.Title,
                Description = taskDto.Description
            };
        }        

        public Entities.Task ToEntity(RequestTaskUpdate taskDto)
        {
            return new Entities.Task
            {
                Name = taskDto.Name,
                Title = taskDto.Title,
                Description = taskDto.Description
            };
        }
       
    }
}
