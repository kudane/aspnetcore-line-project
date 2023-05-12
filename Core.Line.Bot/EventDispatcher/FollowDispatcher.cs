namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class FollowDispatcher : EventDispatcher.ToFollow
    {
        private readonly IServiceProvider serviceProvider;

        public FollowDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var caseHandlers = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Follow);

            foreach (var caseHandler in caseHandlers)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
