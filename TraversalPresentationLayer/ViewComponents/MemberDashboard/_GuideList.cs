using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        GuideManager _guideManager = new GuideManager(new EFGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
    }
}
