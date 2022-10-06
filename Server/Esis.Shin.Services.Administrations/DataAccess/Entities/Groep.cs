namespace Esis.Shin.Services.Administrations.DataAccess.Entities
{
    public class Groep
    {
        public Guid GroepId { get; set; }
        
        public string Name { get; set; } = String.Empty;

        public Guid VestigingId { get; set; }

        public Vestiging? Vestiging { get; set; }

        public IList<Leerling> Leerlingen { get; } = new List<Leerling>();
    }
}
