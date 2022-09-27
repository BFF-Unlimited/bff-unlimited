namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class LaatstBekekenPagina
    {
        public Guid LaatstBekekenPaginaId { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}