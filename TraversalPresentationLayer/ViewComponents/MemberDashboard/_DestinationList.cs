using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.ViewComponents.MemberDashboard
{
    public class _DestinationList : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _DestinationList(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
