namespace Infrastructure.Data.Sqllite
{
    public class LineDbContext : DbContext
    {
        public LineDbContext(DbContextOptions<LineDbContext> options) : base(options)
        {
        }

        public DbSet<LineUser> LineUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source=linedb.db");
        }
    }
}
