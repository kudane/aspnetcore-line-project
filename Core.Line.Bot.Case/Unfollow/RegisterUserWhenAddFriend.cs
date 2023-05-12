namespace Core.Line.Bot.Case
{
    [RegisterAsScoped]
    public sealed class RemoveUserWhenUnFriend : CaseHandler.OfUnfollow
    {
        private readonly LineDbContext context;

        public RemoveUserWhenUnFriend(LineDbContext context)
        {
            this.context = context;
        }

        public override async Task HandleAsync(ILineBot lineBot, ILineEvent evt)
        {
            var lineUser = await context.LineUsers.FirstOrDefaultAsync(a => a.UserId == evt.Source.User.Id);

            if (lineUser == null)
            {
                throw new Exception("Line-User Not Found!.");
            }
            
            context.Remove(lineUser);

            context.SaveChanges();
        }
    }
}
