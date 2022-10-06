namespace Esis.Shin.Services.Administrations.Requests.Dto
{
    public class NotitieDto
    {
        public Guid LeerlingId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}