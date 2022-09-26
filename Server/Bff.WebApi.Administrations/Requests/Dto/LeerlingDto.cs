namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class LeerlingDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid GroepId { get; set; }
    }
}