namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class ReplyLineId : CaseHandler.OfMessage
    {
        public override bool Matching(string data)
        {
            return data == "?user-id";
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var response = new TextMessage(evt.Source.User.Id);

            await lineBot.Reply(evt.ReplyToken, response);
        }
    }
}
