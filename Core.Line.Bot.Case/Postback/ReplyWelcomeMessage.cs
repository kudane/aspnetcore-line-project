namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class ReplyWelcomeMessage : CaseHandler.OfPostback
    {
        public override bool Matching(string data)
        {
            return data == "welcome";
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var response = new TextMessage("Welcome");

            await lineBot.Reply(evt.ReplyToken, response);
        }
    }
}
