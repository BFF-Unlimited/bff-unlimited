namespace Esis.Shin.Services.Administrations.DataAccess.Entities
{
    public class Permission
    {
        public Guid PermissionId { get; set; }
        public string CategoryDescription { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
