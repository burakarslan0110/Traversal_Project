using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EFCommentDal());
        public IActionResult Index()
        {
            var values = _commentManager.TGetListCommentWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentManager.TGetByID(id);
            _commentManager.TDelete(values);
            return RedirectToAction("Comment","Admin");
        }
    }
}
