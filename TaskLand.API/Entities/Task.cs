using TaskLand.API.Entities.Base;

namespace TaskLand.API.Entities
{
    public class Task : EntityBase
    {
        public string Name { get; set; }    
        public string Title { get; set; }    
        public string Description { get; set; }    
    }
}
