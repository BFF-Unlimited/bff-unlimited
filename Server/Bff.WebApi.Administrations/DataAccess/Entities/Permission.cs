namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Permission
    {
        public Guid PermissionId { get; set; }
        public string CategoryDescription { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
