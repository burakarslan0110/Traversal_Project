using DTOLayer.DTOs.AppRoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleDTO model)
        {
            AppRole role = new AppRole
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            EditRoleDTO model = new EditRoleDTO
            {
                RoleID = value.Id,
                RoleName = value.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleDTO p)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == p.RoleID);
            value.Name = p.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");

        }

        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserID"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleDTO> model = new List<AssignRoleDTO>();
            foreach (var item in roles)
            {
                AssignRoleDTO assignRoleDTO = new AssignRoleDTO
                {
                    RoleID = item.Id,
                    RoleName = item.Name,
                    RoleExist = userRoles.Contains(item.Name)
                };
                model.Add(assignRoleDTO);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDTO> model)
        {
            var userid = (int)TempData["UserID"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
