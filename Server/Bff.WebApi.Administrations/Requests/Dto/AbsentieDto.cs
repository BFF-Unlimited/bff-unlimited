namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class AbsentieDto
    {
        public Guid LeerlingId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
