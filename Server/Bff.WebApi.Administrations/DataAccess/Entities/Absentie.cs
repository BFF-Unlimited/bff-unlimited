namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Absentie
    {
        public Guid AbsentieId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid LeerlingId { get; set; }
        public Leerling Leerling { get; set; }
    }
}