namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Leerling
    {
        public Guid LeerlingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid GroepId { get; set; }
        public Groep Groep { get; set; }

        public ICollection<Absentie> Absenties { get; set; }

        public ICollection<Notitie> Notities { get; set; }
    }
}
