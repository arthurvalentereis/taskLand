namespace TaskLand.API.DTO.Response
{
    public class ResponseTask
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
