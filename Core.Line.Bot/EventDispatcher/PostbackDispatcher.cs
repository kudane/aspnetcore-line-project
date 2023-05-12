namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class PostbackDispatcher : EventDispatcher.ToPostback
    {
        private readonly IServiceProvider serviceProvider;

        public PostbackDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            if (string.IsNullOrEmpty(evt.Message?.Text))
                return;

            var caseHandler = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Postback)
                .FirstOrDefault(a => a.Matching(evt.Postback.Data));

            if (caseHandler != null)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
