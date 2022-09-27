namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Groep
    {
        public Guid GroepId { get; set; }
        public string Name { get; set; }


        public Guid VestigingId { get; set; }
        public Vestiging Vestiging { get; set; }

        public ICollection<Leerling> Leerlingen { get; set; }


    }
}
