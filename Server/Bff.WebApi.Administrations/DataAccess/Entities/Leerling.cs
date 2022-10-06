namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Leerling
    {
        public Guid LeerlingId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }

        public Guid GroepId { get; set; }
        public Groep? Groep { get; set; }

        public IList<Absentie> Absenties { get; } = new List<Absentie>();

        public IList<Notitie> Notities { get; } = new List<Notitie>();
    }
}
