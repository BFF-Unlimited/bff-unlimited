namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; } = String.Empty;
        public VestigingIdentificationDto? ActiveVestiging { get; set; }
        public GroepIdentificationDto? ActiveGroep { get; set; }
        public IList<VestigingIdentificationDto> Vestigingen { get; } = new List<VestigingIdentificationDto>();
        public IList<GroepIdentificationDto> Groepen { get; } = new List<GroepIdentificationDto>();
        public IList<PermissionDto> Permissions { get; } = new List<PermissionDto>();
    }
}