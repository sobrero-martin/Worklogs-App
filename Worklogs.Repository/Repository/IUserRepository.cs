using Worklogs.DB.Data.Entities;
using Worklogs.Shared.DTO;

namespace Worklogs.Repository.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<int> Login(LoginDTO login);

        //Task<User?> GetByEmail(string email);
    }
}