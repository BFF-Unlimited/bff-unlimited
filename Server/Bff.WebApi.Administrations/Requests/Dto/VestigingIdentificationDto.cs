namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class VestigingIdentificationDto : BaseDto
    {
        public string LogoUrl { get; set; }
        public string Name { get; set; }

        public VestigingIdentificationDto(string logoUrl, string name)
        {
            Id = Guid.NewGuid();
            LogoUrl = logoUrl;
            Name = name;
        }
    }
}