using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _SliderPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        List<Destination> destinations = new List<Destination> ();
        public IViewComponentResult Invoke()
        {
            destinations = _destinationService.TGetList();
            return View(destinations);
        }
    }
}
