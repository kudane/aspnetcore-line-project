namespace Core.Line.Bot.Sheared
{
    public interface ICaseHandler
    {
        LineEventType EventType { get; }
        bool Matching(string data);
        Task HandleAsync(ILineBot lineBot, ILineEvent evt);
    }
}
