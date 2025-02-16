using EFC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _context;

        public GenreController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }   

        
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Management");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre Genre)
        {
            if (ModelState.IsValid)
            {
                Genre GenreReal = new Genre()
                {
                    Name = Genre.Name,
                    Description = Genre.Description,
                    Color=Genre.Color
                    
                };
                await _context.genres.AddAsync(GenreReal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Genres", "Management");
            }

            return View(Genre);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var Entity = await _context.genres.FirstOrDefaultAsync(x=>x.GenreId == id);
                return View(Entity);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Genre Genre)
        {
            if (id != null && id == Genre.GenreId)
            {
                var Entity = await _context.genres.FirstOrDefaultAsync(x => x.GenreId == Genre.GenreId);
                if (Entity != null)
                {
                    Entity.Name = Genre.Name;
                    Entity.Description = Genre.Description;
                    Entity.Color = Genre.Color;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Genres", "management");
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Genre = await _context.genres
                .FirstOrDefaultAsync(m => m.GenreId == id);
            if (Genre == null)
            {
                return NotFound();
            }

            return View(Genre);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id,Genre Genre)
        {
            var confirmedGenre = await _context.genres.FirstOrDefaultAsync(isd=>isd.GenreId == id);
            _context.genres.Remove(confirmedGenre!);
            await _context.SaveChangesAsync();
            return RedirectToAction("Genres", "Management");
        }
        
    }
}