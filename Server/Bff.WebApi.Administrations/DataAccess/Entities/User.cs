namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
