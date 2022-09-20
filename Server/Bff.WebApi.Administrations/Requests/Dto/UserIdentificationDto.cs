namespace Bff.WebApi.Services.Administrations.Requests.Dto;

public class UserIdentificationDto : BaseDto
{
    public string UserName { get; set; }

    public UserIdentificationDto(string userName)
    {
        Id = Guid.NewGuid();
        UserName = userName;
    }
}