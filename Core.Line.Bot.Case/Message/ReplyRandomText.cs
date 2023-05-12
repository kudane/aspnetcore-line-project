namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class ReplyRandomText : CaseHandler.OfMessage
    {
        public override bool Matching(string data)
        {
            return data == "?random";
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var response = new TextMessage(Path.GetRandomFileName());

            await lineBot.Reply(evt.ReplyToken, response);
        }
    }
}
