namespace Presentation.Web.Controllers
{
    [Area("Web")]
    public class BaseWebController : Controller
    {
        protected IMediator mediator { get; set; }

        public BaseWebController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}