namespace Esis.Shin.Services.Administrations.Requests.Dto
{
    public class PermissionDto
    {
        public string Id { get; set; }
        public string CategoryDescription { get; set; }
        public string Description { get; set; }

        public PermissionDto(string id, string categoryDescription, string description)
        {
            Id = id;
            CategoryDescription = categoryDescription;
            Description = description;
        }
    }
}