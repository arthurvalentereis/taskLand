using TaskLand.API.DTO.Request;

namespace TaskLand.API.Interfaces.Services
{
    public interface ITaskService
    {
        Task<Entities.Task> GetTask(long taskId);
        Task<Entities.Task> Create(RequestTaskCreate task);
        Task<Entities.Task> Update(long taskId, RequestTaskUpdate task);
        Task<Entities.Task> Delete(long taskId);
        Task<List<Entities.Task>> List();
    }
}
