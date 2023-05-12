namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class LeaveDispatcher : EventDispatcher.ToLeave
    {
        private readonly IServiceProvider serviceProvider;

        public LeaveDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var caseHandlers = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Leave);

            foreach (var caseHandler in caseHandlers)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
