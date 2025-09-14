
using Worklogs.DB.Data;

namespace Worklogs.Repository.Repository
{
    public interface IRepository<E> where E : class, IBaseEntity
    {
        Task<bool> Delete(int id);
        Task<bool> Existe(int id);
        Task<E?> GetById(int id);
        Task<List<E>> GetFull();
        Task<int> Post(E entidad);
        Task<bool> Put(int id, E entidad);
    }
}