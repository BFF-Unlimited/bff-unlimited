namespace Esis.Shin.Services.Administrations.DataAccess.Entities
{
    public class Notitie
    {
        public Guid NotitieId { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public string Description { get; set; } = String.Empty;

        public Guid LeerlingId { get; set; }
        public Leerling? Leerling { get; set; }
    }
}