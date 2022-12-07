using CoreTeam.Models;
public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseSqlServer("Data Source=DESKTOP-LL3BIEJ;Initial Catalog=YM;Integrated Security=True");
    }
    public DbSet<User> Users => Set<User>();
    }
