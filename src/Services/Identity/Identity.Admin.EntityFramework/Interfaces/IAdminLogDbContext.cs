using Microsoft.EntityFrameworkCore;
using Identity.Admin.EntityFramework.Entities;

namespace Identity.Admin.EntityFramework.Interfaces
{
    public interface IAdminLogDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}
