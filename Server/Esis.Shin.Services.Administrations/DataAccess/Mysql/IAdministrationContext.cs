using Esis.Shin.Services.Administrations.DataAccess.Entities;

namespace Esis.Shin.Services.Administrations.DataAccess.Mysql
{
    public interface IAdministrationContext
    {
        Task<User?> GetUser(string username, string password);
    }
}
