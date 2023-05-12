namespace Core.Line.Bot
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly IWebhookHandler webhook;

        public WebhookController(IWebhookHandler webhook)
        {
            this.webhook = webhook;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            await webhook.HandleAsync(HttpContext);
            return Ok();
        }
    }
}
