namespace TaskLand.API.Entities.Base
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }
        public EntityBase()
        {
            IsDeleted = true;
        }
    }
}
