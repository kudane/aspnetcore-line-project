namespace Presentation.Liff.Controllers
{
    [Area("Liff")]
    public class BaseLiffController : Controller
    {
        protected IMediator mediator { get; set; }

        public BaseLiffController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}