using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace TaskLand.API.Data.EntitiesMappers
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {

            builder.ToTable("task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }
}
