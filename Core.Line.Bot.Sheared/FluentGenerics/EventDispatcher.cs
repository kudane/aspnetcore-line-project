namespace Core.Line.Bot.Sheared
{
    public static class EventDispatcher
    {
        public abstract class ToFollow : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Follow;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }

        public abstract class ToJoin : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Join;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }

        public abstract class ToLeave : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Leave;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }

        public abstract class ToMessage : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Message;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }

        public abstract class ToPostback : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Postback;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }

        public abstract class ToUnfollow : IEventDispatcher
        {
            public LineEventType EventType => LineEventType.Unfollow;
            public abstract Task HandleAsync(ILineBot lineBot, ILineEvent evt);
        }
    }
}
