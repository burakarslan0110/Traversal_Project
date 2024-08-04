using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _Feature1 : ViewComponent
    {
        private readonly IFeature1Service _feature1Service;

        public _Feature1(IFeature1Service feature1Service)
        {
            _feature1Service = feature1Service;
        }

        public IViewComponentResult Invoke()
        {
            var values = _feature1Service.TGetList().Take(5).ToList();
            return View(values); 
        }
    
        
    }
}
