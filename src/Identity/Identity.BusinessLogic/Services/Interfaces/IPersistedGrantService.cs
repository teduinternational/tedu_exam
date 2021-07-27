using System.Threading.Tasks;
using Identity.BusinessLogic.Dtos.Grant;

namespace Identity.BusinessLogic.Services.Interfaces
{
    public interface IPersistedGrantService
    {
        Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10);
        Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10);
        Task<PersistedGrantDto> GetPersistedGrantAsync(string key);
        Task<int> DeletePersistedGrantAsync(string key);
        Task<int> DeletePersistedGrantsAsync(string userId);
    }
}