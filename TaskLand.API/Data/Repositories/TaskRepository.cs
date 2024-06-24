using TaskLand.API.Data.Contexts;
using TaskLand.API.Data.Repositories.Base;
using TaskLand.API.Interfaces.Repositories;
using TaskLand.API.Interfaces.Repositories.Base;

namespace TaskLand.API.Data.Repositories
{
    public class TaskRepository : RepositoryBase<Entities.Task,long>, ITaskRepository
    {
        private TaskDbContext _context;
        public TaskRepository(TaskDbContext context
            ) : base(context)
        {
            _context = context;
        }
    }
}
