namespace TaskLand.API.DTO.Request
{
    public record RequestTaskUpdate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
