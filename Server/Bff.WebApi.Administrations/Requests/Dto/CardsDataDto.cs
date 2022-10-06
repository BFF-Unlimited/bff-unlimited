namespace Bff.WebApi.Services.Administrations.Requests.Dto
{
    public class CardsDataDto
    {
        public IList<LaatstBekekenPaginaDto> LaatstBekekenPaginas { get; } = new List<LaatstBekekenPaginaDto>();
        public IList<KoppelingDto> Koppelingen { get; } = new List<KoppelingDto>();
        public IList<AbsentieDto> Absenties { get; } = new List<AbsentieDto>();
        public IList<NotitieDto> Notities { get; } = new List<NotitieDto>();
        public IList<LeerlingDto> JarigeLeerlingen { get; } = new List<LeerlingDto>();
    }
}
