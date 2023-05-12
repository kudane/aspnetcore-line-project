namespace Core.Line.Bot
{
    public static class Startup
    {
        public static void AddLineBot(this IServiceCollection services, IConfiguration configuration)
        {
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                AssemblyHelper.RegisterAllCasesService(),
            };

            services
                // Required DI
                .AddSingleton<ILineConfiguration, LineConfiguration>(sp =>
                {
                    var lineConfiguration = new LineConfiguration();
                    configuration.GetRequiredSection("LineConfiguration").Bind(lineConfiguration);
                    return lineConfiguration;
                })
                .AddScoped<ILineBot, LineBot>()
                .AddScoped<ILineLogger, LoggerHandler>()
                .AddScoped<IWebhookHandler, WebhookHandler>()
                // Dynamic DI
                .RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                // Ignore
                .IgnoreThisInterface<ILineBotLogger>()
                .AsPublicImplementedInterfaces();
        }
    }
}
