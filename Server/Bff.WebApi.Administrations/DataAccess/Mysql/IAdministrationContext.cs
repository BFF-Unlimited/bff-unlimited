using Bff.WebApi.Services.Administrations.DataAccess.Entities;

namespace Bff.WebApi.Services.Administrations.DataAccess.Mysql
{
    public interface IAdministrationContext
    {
        Task<User?> GetUser(string username, string password);
    }
}
