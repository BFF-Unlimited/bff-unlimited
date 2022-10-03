namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public VestigingIdentificationDto ActiveVestiging { get; set; }
        public GroepIdentificationDto ActiveGroep { get; set; }
        public VestigingIdentificationDto[] Vestigingen { get; set; }
        public GroepIdentificationDto[] Groepen { get; set; }
        public PermissionDto[] Permissions { get; set; }

        public UserDto(string userName, VestigingIdentificationDto activeVestiging, GroepIdentificationDto activeGroep,
            VestigingIdentificationDto[] vestigingen, GroepIdentificationDto[] groepen, PermissionDto[] permissions)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            ActiveVestiging = activeVestiging;
            ActiveGroep = activeGroep;
            Vestigingen = vestigingen;
            Groepen = groepen;
            Permissions = permissions;
        }
    }
}