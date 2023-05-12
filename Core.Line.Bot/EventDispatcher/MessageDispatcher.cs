namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class MessageDispatcher : EventDispatcher.ToMessage
    {
        private readonly IServiceProvider serviceProvider;

        public MessageDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            if (string.IsNullOrEmpty(evt.Message?.Text))
                return;

            var caseHandler = serviceProvider
                .GetServices<ICaseHandler>()
                .Where(a => a.EventType == LineEventType.Message)
                .FirstOrDefault(a => a.Matching(evt.Message.Text));

            if (caseHandler != null)
            {
                await caseHandler.HandleAsync(lineBot, evt);
            }
        }
    }
}
