namespace Presentation.Web.Controllers
{
    public class HomeController : BaseWebController
    {
        public HomeController(IMediator mediator):base(mediator)
        {
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Info = await mediator.Send(new GetWebInfo.Command());
            return View();
        }
    }
}