using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager _subAboutManager = new SubAboutManager(new EFSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = _subAboutManager.TGetList();
            return View(values);
        }
    }
}
