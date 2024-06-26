using TaskLand.API.Data.Contexts;
using TaskLand.API.Interfaces.Repositories;
using TaskLand.API.Interfaces.Repositories.Base;

namespace TaskLand.API.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _taskDbContext;

        public UnitOfWork(TaskDbContext taskDbContext) 
        {
            _taskDbContext = taskDbContext;
        }

        public ITaskRepository TaskRepository => new TaskRepository(_taskDbContext);

        public void Dispose()
        {
            _taskDbContext.Dispose();
        }

        public void SaveChanges()
        {
            _taskDbContext.SaveChanges();
        }
    }
}
