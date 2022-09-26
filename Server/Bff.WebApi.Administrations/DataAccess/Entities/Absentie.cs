namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Absentie
    {
        public Guid Id { get; set; }
        public Guid LeerlingId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}