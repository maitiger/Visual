using Authentication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication1.Controllers
{
    namespace WebApplication3.Controllers
    {
        public class RolesController : Controller
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<CustomizeUser> _customizeManager;

            public RolesController(RoleManager<IdentityRole> roleManager, UserManager<CustomizeUser> customizeManager)
            {
                _roleManager = roleManager;
                _customizeManager = customizeManager;
            }
            public ActionResult Index()
            {
                return View(_roleManager.Roles.ToList());
            }

            public ActionResult Details(int id)
            {
                return View();
            }

            public ActionResult Create()
            {
                var user = _customizeManager.Users
                    .Include(r => r.Role)
                    .ToList();
                return View(user);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(string name)
            {
                try
                {
                    var result = _roleManager.CreateAsync(new IdentityRole(name)).Result;

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            public async Task<IActionResult> Edit(int id)
            {
                //var role = await _roleManager.Roles.FirstOrDefaultAsync(m => m.Id == id);
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(string id, string name)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    if (role != null)
                    {
                        role.Name = name;
                        var result = await _roleManager.UpdateAsync(role);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            public async Task<ActionResult> Delete(string id, string name)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    if (role != null)
                    {
                        role.Name = name;
                        var result = await _roleManager.DeleteAsync(role);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Delete(string id)
            {
                try
                {

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}