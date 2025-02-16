using EFC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC.Controllers
{
    public class DirectorController : Controller
    {
        private readonly AppDbContext _context;

        public DirectorController(AppDbContext appContext)
        {
            _context = appContext;
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
        public async Task<IActionResult> Create(Director Director, IFormFile? formImg)
        {

            var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (formImg != null)
            {

                var extension = Path.GetExtension(formImg!.FileName);
                if (!AllowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("formImg", "Resim dosyası seçiniz.");
                }
                else
                {
                    var fileName = Guid.NewGuid() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formImg.CopyToAsync(stream);
                    }
                    Director.ActorImg = fileName;
                }
            }

            if (ModelState.IsValid)
            {
                Director DirectorReal = new Director()
                {
                    FirstName = Director.FirstName,
                    LastName = Director.LastName,
                    Bio = Director.Bio,
                    ActorImg = Director.ActorImg
                    
                };
                await _context.directors.AddAsync(DirectorReal);
                await _context.SaveChangesAsync();
                return RedirectToAction("Directors", "Management");
            }

            return View(Director);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var Entity = await _context.directors.FirstOrDefaultAsync(x => x.DirectorId == id);
                return View(Entity);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Director Director,IFormFile formImg)
        {
            var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (formImg != null)
            {
                var extension = Path.GetExtension(formImg!.FileName);
                if (!AllowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("formImg", "Resim dosyası seçiniz.");
                }
                else
                {
                    var fileName = Guid.NewGuid() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formImg.CopyToAsync(stream);
                    }
                    Director.ActorImg = fileName;
                }
            }
            else
            {
                var Entity = await _context.directors.FirstOrDefaultAsync(x => x.DirectorId == id);
                Director.ActorImg = Entity!.ActorImg;
            }
            if (id != null && id == Director.DirectorId)
            {
                var Entity = await _context.directors.FirstOrDefaultAsync(x => x.DirectorId == Director.DirectorId);
                if (Entity != null)
                {
                    Entity.FirstName = Director.FirstName;
                    Entity.LastName = Director.LastName;
                    Entity.Bio = Director.Bio;
                    Entity.ActorImg = Director.ActorImg;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Directors", "management");
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Director = await _context.directors
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (Director == null)
            {
                return NotFound();
            }

            return View(Director);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Director Director)
        {
            var confirmedDirector = await _context.directors.FirstOrDefaultAsync(isd => isd.DirectorId == id);
            _context.directors.Remove(confirmedDirector!);
            await _context.SaveChangesAsync();
            return RedirectToAction("Directors", "Management");
        }
    }
}