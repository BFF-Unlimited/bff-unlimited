namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class GroepIdentificationDto : BaseDto
    {
        public string Name { get; set; }

        public GroepIdentificationDto(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}