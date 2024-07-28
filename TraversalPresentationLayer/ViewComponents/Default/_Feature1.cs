using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _Feature1 : ViewComponent
    {
        Feature1Manager _feature1Manager = new Feature1Manager(new EFFeature1Dal());
        public IViewComponentResult Invoke()
        {
            var values = _feature1Manager.TGetList().Take(5).ToList();
            return View(values); 
        }
    
        
    }
}
