namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class WebhookHandler : IWebhookHandler
    {
        private readonly ILineBot lineBot;
        private readonly ILineLogger lineLogger;
        private readonly IServiceProvider serviceProvider;

        public WebhookHandler(ILineBot lineBot, ILineLogger lineLogger, IServiceProvider serviceProvider)
        {
            this.lineBot = lineBot;
            this.lineLogger = lineLogger;
            this.serviceProvider = serviceProvider;
        }

        public async Task HandleAsync(HttpContext context)
        {
            if (context.Request.Method != HttpMethods.Post)
                return;

            var events = await lineBot.GetEvents(context.Request);

            foreach (var evt in events)
            {
                foreach (var eventHandler in GetEventHandlers(evt.EventType))
                {
                    try
                    {
                        await eventHandler.HandleAsync(lineBot, evt);
                    }
                    catch (Exception ex)
                    {
                        await lineLogger.LogExceptionEvents(ex);
                    }
                }
            }
        }

        private IEnumerable<IEventDispatcher> GetEventHandlers(LineEventType eventType)
        {
            return serviceProvider
                .GetServices<IEventDispatcher>()
                .Where(_ => _.EventType == eventType);
        }
    }
}
