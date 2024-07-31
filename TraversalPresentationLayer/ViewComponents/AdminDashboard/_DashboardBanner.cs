using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.ViewComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
