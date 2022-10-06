namespace Esis.Shin.Services.Administrations.DataAccess.Entities
{
    public class Koppeling
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string LogoUrl { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;
    }
}