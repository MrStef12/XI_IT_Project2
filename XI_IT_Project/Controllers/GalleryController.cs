using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using XI_IT_Project_assignment_2.Data;
using Microsoft.EntityFrameworkCore;
using Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XI_IT_Project.Controllers
{
    public class GalleryController : Controller
    {
        private DataContext _context;

        public GalleryController(DataContext context)
        {
            _context = context;
        }

        // GET: /Gallery/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New([Bind("Title", "Name", "Email", "ImgUrl")] Image image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(image);
                    await _context.SaveChangesAsync();
                    return Redirect("Index");
                }
            } catch(DbUpdateException)
            {
                ModelState.AddModelError("create", "Unable to saves changes to DB!");
            }
            return View(image);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            Image i = await _context.Images.AsNoTracking().SingleOrDefaultAsync(m => m.Id == Id);

            if (i == null)
            {
                return Redirect("~/Gallery/Overview");
            }

            try
            {
                _context.Images.Remove(i);
                await _context.SaveChangesAsync();
                return Redirect("~/Gallery/Overview");
            } catch (DbUpdateException)
            {
                ModelState.AddModelError("delete", "Unable to delete item");
            }
            return Redirect("~/Gallery/Overview");
        }

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            return View(await _context.Images.ToListAsync());
        }
    }
}
