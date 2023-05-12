namespace Infrastructure.Data.EfCore
{
    public class SimpleContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}
