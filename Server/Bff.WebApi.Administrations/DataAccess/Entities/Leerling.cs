namespace Bff.WebApi.Services.Administrations.DataAccess.Entities
{
    public class Leerling
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid GroepId { get; set; }
    }
}
