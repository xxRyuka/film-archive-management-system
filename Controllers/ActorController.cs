using EFC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext appContext)
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
        public async Task<IActionResult> Create(Actor actor , IFormFile? formImg)
        {
            if (formImg != null)
            {
                var AllowedExtensions = new[] {".jpg", ".jpeg", ".png", ".gif"};
                var extension = Path.GetExtension(formImg.FileName);
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
                    actor.ActorImg = fileName;
                }
            }

            if (ModelState.IsValid)
            {
                Actor actorReal = new Actor()
                {   
                    ActorImg=actor.ActorImg,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName
                };
                await _context.actors.AddAsync(actorReal);
                await _context.SaveChangesAsync();
                return RedirectToAction("actors", "Management");
            }

            return View(actor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var Entity = await _context.actors.FirstOrDefaultAsync(x => x.ActorId == id);
                return View(Entity);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Actor actor,IFormFile formImg)
        {
            if (formImg != null)
            {
                var AllowedExtensions = new[] {".jpg", ".jpeg", ".png", ".gif"};
                var extension = Path.GetExtension(formImg.FileName);
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
                    actor.ActorImg = fileName;
                }
            }
            else
            {
                var Entity = await _context.actors.FirstOrDefaultAsync(x => x.ActorId == id);
                actor.ActorImg = Entity!.ActorImg;
            }

            if (id != null && id == actor.ActorId)
            {
                var Entity = await _context.actors.FirstOrDefaultAsync(x => x.ActorId == actor.ActorId);
                if (Entity != null)
                {
                    Entity.FirstName = actor.FirstName;
                    Entity.LastName = actor.LastName;
                    Entity.ActorImg = actor.ActorImg;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("actors", "management");
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.actors
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id,Actor actor)
        {
            var confirmedActor = await _context.actors.FirstOrDefaultAsync(isd=>isd.ActorId == id);
            _context.actors.Remove(confirmedActor!);
            await _context.SaveChangesAsync();
            return RedirectToAction("actors", "Management");
        }
    }
}