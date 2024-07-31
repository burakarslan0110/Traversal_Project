using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.ViewComponents.AdminDashboard
{
    public class _AdminGuideList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
