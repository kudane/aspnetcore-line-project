using Microsoft.AspNetCore.Http;

namespace Core.Line.Bot.Sheared
{
    public interface IWebhookHandler
    {
        Task HandleAsync(HttpContext context);
    }
}
