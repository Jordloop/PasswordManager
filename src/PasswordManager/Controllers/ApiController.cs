using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PasswordManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;



namespace PasswordManager.Controllers
{
    [Authorize]
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser>_userManager;

        public ApiController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        //Index - Returns all of authenticated user's Site objects
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Apis.Where(x => x.User.Id == currentUser.Id));
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Api api)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            api.User = currentUser;
            _db.Apis.Add(api);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit
        public IActionResult Edit(int id)
        {
            var thisApi = _db.Apis.FirstOrDefault(api => api.Id == id);
            return View(thisApi);
        }
        [HttpPost]
        public IActionResult Edit(Api api)
        {
            _db.Entry(api).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisApi = _db.Apis.FirstOrDefault(api => api.Id == id);
            _db.Apis.Remove(thisApi);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

