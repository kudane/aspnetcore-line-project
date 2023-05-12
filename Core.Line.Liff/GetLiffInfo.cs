namespace Core.Line.Liff
{
    public sealed class GetLiffInfo
    {
        public class Command : IRequest<string>
        {
        }

        public class Handler : IRequestHandler<Command, string>
        {
            public Handler()
            {
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                return await Task.FromResult("This is Core Liff");
            }
        }
    }
}
