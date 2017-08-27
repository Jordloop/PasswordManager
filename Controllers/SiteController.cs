﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PasswordManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Controllers
{
    public class SiteController
    {
        [Authorize]
        public class ToDoController : Controller
        {
            private readonly ApplicationDbContext _db;
            private readonly UserManager<ApplicationUser> _userManager;

            public ToDoController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
            {
                _userManager = userManager;
                _db = db;
            }
//Index - Returns all of authenticated user's Site objects
            public async Task<IActionResult> Index()
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                return View(_db.Sites.Where(x => x.User.Id == currentUser.Id));
            }
//Create
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Create(Site site)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                site.User = currentUser;
                _db.Sites.Add(site);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
//Edit
            public IActionResult Edit(int id)
            {
                var thisSite= _db.Sites.FirstOrDefault(sites => sites.Id == id);
                return View(thisSite);
            }
            [HttpPost]
            public IActionResult Edit(Site site)
            {
                _db.Entry(site).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
//Delete
            public IActionResult Delete(int id)
            {
                var thisSite = _db.Sites.FirstOrDefault(sites => sites.Id == id);
                return View(thisSite);
            }

            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                var thisItem = _db.Sites.FirstOrDefault(sites => sites.Id == id);
                _db.Sites.Remove(thisItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

