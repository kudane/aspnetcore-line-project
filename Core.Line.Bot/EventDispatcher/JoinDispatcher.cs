namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class JoinDispatcher : EventDispatcher.ToJoin
    {
        private readonly IServiceProvider serviceProvider;

        public JoinDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var caseHandlers = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Join);

            foreach (var caseHandler in caseHandlers)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
