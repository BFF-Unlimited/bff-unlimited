namespace Esis.Shin.Services.Administrations.Requests.Dto
{
    public class LeerlingDto : BaseDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}