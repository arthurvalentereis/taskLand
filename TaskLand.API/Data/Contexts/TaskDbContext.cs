using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaskLand.API.Data.EntitiesMappers;

namespace TaskLand.API.Data.Contexts
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> BankStatement { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
