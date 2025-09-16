using Microsoft.EntityFrameworkCore;

namespace jobs_api.Persistency
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {
        }
}
}
