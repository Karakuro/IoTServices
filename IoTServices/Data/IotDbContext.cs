using Microsoft.EntityFrameworkCore;

namespace IoTServices.Data
{
    public class IotDbContext : DbContext
    {
        public IotDbContext() : base() { }

        public IotDbContext(DbContextOptions<IotDbContext> options) : base(options) { }

        public DbSet<IotData> IotData { get; set; }
    }
}
