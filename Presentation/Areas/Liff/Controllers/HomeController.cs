namespace Presentation.Liff.Controllers
{
    public class HomeController : BaseLiffController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {   
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Info = await mediator.Send(new GetLiffInfo.Command());
            return View();
        }
    }
}