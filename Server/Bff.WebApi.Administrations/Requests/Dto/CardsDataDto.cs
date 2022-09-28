namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class CardsDataDto
    {
        public LaatstBekekenPaginaDto[] LaatstBekekenPaginas { get; set; }
        public KoppelingDto[] Koppelingen { get; set; }
        public AbsentieDto[] Absenties { get; set; }
        public NotitieDto[] Notities { get; set; }
        public LeerlingDto[] JarigeLeerlingen { get; set; }
    }
}
