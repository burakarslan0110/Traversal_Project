using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalPresentationLayer.CQRS.Commands.DestinationCommands;
using TraversalPresentationLayer.CQRS.Commands.GuideCommands;
using TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers;
using TraversalPresentationLayer.CQRS.Queries.GuideQueries;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> GetGuides(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteGuide(int id)
        {
            await _mediator.Send(new DeleteGuideCommand(id));
            return RedirectToAction("Index");
        }

    }
}
