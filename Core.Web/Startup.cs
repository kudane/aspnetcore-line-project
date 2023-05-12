namespace Core.Web
{
    public static class Startup
    {
        public static void AddCoreWeb(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
