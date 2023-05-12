namespace Core.Line.Bot.Sheared
{
    public interface ILineLogger: ILineBotLogger
    {
        Task LogExceptionEvents(Exception exception);
    }
}
