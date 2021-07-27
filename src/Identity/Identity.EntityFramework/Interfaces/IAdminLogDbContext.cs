using Microsoft.EntityFrameworkCore;
using Identity.EntityFramework.Entities;

namespace Identity.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
