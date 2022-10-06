namespace Esis.Shin.Services.Administrations.DataAccess.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public IList<Permission> Permissions { get; } = new List<Permission>();
    }
}
