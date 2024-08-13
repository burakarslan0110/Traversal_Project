using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class PacketsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public PacketsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        List<Destination> packet = new List<Destination>();
        public IActionResult Index()
        {
            packet = _destinationService.TGetList();
            return View(packet);
        }
    }
}
