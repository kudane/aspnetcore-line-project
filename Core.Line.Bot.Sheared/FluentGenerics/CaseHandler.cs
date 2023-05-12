namespace Core.Line.Bot.Sheared
{
    public static class CaseHandler
    {
        public abstract class OfFollow : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Follow;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public virtual bool Matching(string data) => true;
        }

        public abstract class OfJoin : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Join;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public abstract bool Matching(string data);
        }

        public abstract class OfLeave : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Leave;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public abstract bool Matching(string data);
        }

        public abstract class OfMessage : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Message;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public abstract bool Matching(string data);
        }

        public abstract class OfPostback : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Postback;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public abstract bool Matching(string data);
        }

        public abstract class OfUnfollow : ICaseHandler
        {
            public LineEventType EventType => LineEventType.Unfollow;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
            public virtual bool Matching(string data) => true;
        }
    }
}
