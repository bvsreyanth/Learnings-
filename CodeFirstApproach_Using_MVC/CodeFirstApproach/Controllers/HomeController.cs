using CodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _studentDbContext;

        public HomeController(ILogger<HomeController> logger, StudentDbContext studentDbContext)
        {
            _logger = logger;
            _studentDbContext = studentDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var StdData = await _studentDbContext.Students.ToArrayAsync();
            return View(StdData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await _studentDbContext.Students.AddAsync(std);
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task<IActionResult> Details(int? id)
        {   
            if(id == null|| _studentDbContext.Students==null)
            {
                return NotFound();
            }
            var stdData = await _studentDbContext.Students.FirstOrDefaultAsync(u=>u.Id==id);
            if(stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentDbContext.Students == null)
            {
                return NotFound();
            }
            var stdData = await _studentDbContext.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student std)
        {
            if(std == null)
            {
                return NoContent();
            }
            if (ModelState.IsValid)
            {
                 _studentDbContext.Students.Update(std);
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            var stdData = await _studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(stdData);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdData = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (stdData != null)
            {
                _studentDbContext.Students.Remove(stdData);
                await _studentDbContext.SaveChangesAsync();
            }
           
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}