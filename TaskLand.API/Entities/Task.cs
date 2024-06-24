using TaskLand.API.Entities.Base;

namespace TaskLand.API.Entities
{
    public class Task : EntityBase
    {
        public string Name { get; set; }    
        public string Description { get; set; }    
        public string Status { get; set; }    
    }
}
