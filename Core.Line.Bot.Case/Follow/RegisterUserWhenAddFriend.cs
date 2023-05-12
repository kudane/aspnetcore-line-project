namespace Core.Line.Bot.Case
{
    [RegisterAsScoped]
    public sealed class RegisterUserWhenAddFriend : CaseHandler.OfFollow
    {
        private readonly LineDbContext context;

        public RegisterUserWhenAddFriend(LineDbContext context)
        {
            this.context = context;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var lineUser = await lineBot.GetProfile(evt.Source.User);

            if (lineUser == null)
            {
                throw new Exception("Profile Not Found!.");
            }

            var newLineUser = new LineUser()
            {
                UserId = lineUser.UserId,
                DisplayName = lineUser.DisplayName,
                StatusMessage = lineUser.StatusMessage,
                PictureUrl = lineUser.PictureUrl.ToString(),
            };

            context.Add(newLineUser);

            context.SaveChanges();
        }
    }
}
