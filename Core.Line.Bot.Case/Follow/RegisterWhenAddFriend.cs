namespace Core.Line.Bot
{
    [RegisterAsScoped]
    public sealed class RegisterWhenAddFriend : ICaseHandler
    {
        public bool Matching(string data)
        {
            return data == "?user-id";
        }

        public async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var response = new TextMessage(evt.Source.User.Id);

            await lineBot.Reply(evt.ReplyToken, response);
        }
    }
}
