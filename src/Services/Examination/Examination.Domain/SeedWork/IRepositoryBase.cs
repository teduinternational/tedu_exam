using System.Threading;
using System.Threading.Tasks;

namespace Examination.Domain.SeedWork
{
    public interface IRepositoryBase<T> where T : IAggregateRoot
    {
        Task InsertAsync(T obj);

        Task UpdateAsync(T obj);

        Task DeleteAsync(string id);

    }
}