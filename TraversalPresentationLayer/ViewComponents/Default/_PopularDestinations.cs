using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;

namespace Traversal.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
