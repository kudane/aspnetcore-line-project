namespace Infrastructure.Data.EfCore
{
    public static class Startup
    {
        public static void AddEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleContext>(options => options.UseSqlServer(configuration.GetConnectionString("connection_string")));
        }
    }
}