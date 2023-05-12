namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class UnfollowDispatcher : EventDispatcher.ToUnfollow
    {
        private readonly IServiceProvider serviceProvider;

        public UnfollowDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var caseHandlers = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Unfollow);

            foreach (var caseHandler in caseHandlers)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
