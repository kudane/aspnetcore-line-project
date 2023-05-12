namespace Core.Line.Bot.Sheared
{
    public interface IEventDispatcher
    {
        LineEventType EventType { get; }
        Task HandleAsync(ILineBot lineBot, ILineEvent evt);
    }
}
