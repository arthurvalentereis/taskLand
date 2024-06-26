namespace TaskLand.API.Interfaces.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        public ITaskRepository TaskRepository { get; }
        void SaveChanges();
    }
}
