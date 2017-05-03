using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using XI_IT_Project_assignment_2.Data;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult New()
        {
            return View();
        }
    }
}
