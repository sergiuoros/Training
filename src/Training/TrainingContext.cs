using System.Data.Entity;
using Training.Models;

namespace WebApplication1
{

    public partial class TrainingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public TrainingContext()
            : base("data source=CJ1434-LAP\\SQLEXPRESS;initial catalog=Training;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

    }
}
