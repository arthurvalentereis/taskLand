using TaskLand.API.Interfaces.Repositories.Base;

namespace TaskLand.API.Interfaces.Repositories
{
    public interface ITaskRepository : IRepositoryBase<Entities.Task, long>
    {
    }
}
