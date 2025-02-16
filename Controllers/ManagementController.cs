using EFC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC.Controllers
{
    public class ManagementController : Controller
    {
        private readonly AppDbContext _context;

        public ManagementController(AppDbContext appContext)
        {
            _context = appContext;
        }

        public IActionResult Index()
        {
            ViewBag.Actor = _context.actors.Count();
            ViewBag.Director = _context.directors.Count();
            ViewBag.Movie = _context.movies.Count();
            ViewBag.Genre = _context.genres.Count();

            return View();
        }

        public async Task<IActionResult> Actors(string? searchString)
        {
            var list = await _context.actors
            .Include(k => k.Movies)
            .ThenInclude(k => k.Movie)
            .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                list = await _context.actors
                           .Include(m => m.Movies)
                           .ThenInclude(s => s.Movie)
                           .Where(x => x.FirstName!.ToLower().Contains(searchString.ToLower())).ToListAsync();

                ViewBag.search = searchString;
            }
            return View(list);
        }

        public async Task<IActionResult> Directors(string? searchString)
        {
            var list = await _context.directors
            .Include(k => k.Movies)
            .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                list = await _context.directors
                           .Include(m => m.Movies)
                           .Where(x => x.FirstName!.ToLower().Contains(searchString.ToLower())).ToListAsync();

                ViewBag.search = searchString;
            }


            return View(list);
        }

        public async Task<IActionResult> Genres()
        {
            var list = await _context.genres
            .ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Movies(string? searchString)
        {
            var list = await _context.movies
            .Include(k => k.Director)
            .Include(k => k.Genres)
            .ThenInclude(k => k.Genre)
            .ToListAsync();

                        if (!String.IsNullOrEmpty(searchString))
            {
             list = await _context.movies
                        .Include(m=> m.Genres)
                        .ThenInclude(s=>s.Genre)
                        .Include(d=>d.Director)
                        .Where(x=>x.MovieTitle!.ToLower().Contains(searchString.ToLower())).ToListAsync();   

            ViewBag.search=searchString;
            }

            return View(list);
        }
    }
}