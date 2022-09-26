namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Notitie
    {
        public Guid Id { get; set; }
        public Guid LeerlingId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public string Description { get; set; }
    }
}