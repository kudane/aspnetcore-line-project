namespace Infrastructure.Data.Sqllite
{
    public static class Startup
    {
        public static void AddLineUserDB(this IServiceCollection services, IConfiguration configuration)
        {
            var path = configuration.GetConnectionString("Sqllite");

            services.AddDbContext<LineDbContext>(options => options.UseSqlite(path));
        }
    }
}