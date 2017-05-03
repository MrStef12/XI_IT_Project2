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
        public async Task<IActionResult> Create([Bind("Title", "Name", "Email", "ImgUrl")] Image image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(image);
                    await _context.SaveChangesAsync();
                    return Redirect("New");
                }
            } catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to saves changes to DB!");
            }

            return View(image);
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
