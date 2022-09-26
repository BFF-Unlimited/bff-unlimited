namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class CardsDataDto
    {
        public PermissionDto[] LaatstBekekenPaginas { get; set; }
        public KoppelingDto[] Koppelingen { get; set; }
        public AbsentieDto[] Absenties { get; set; }
        public NotitieDto[] Notitie { get; set; }
        public LeerlingDto[] JarigeLeerlingen { get; set; }
    }
}
