using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFC.Data
{



    public class MovieController : Controller
    {

        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string? searchString ,string? filter)
        {



            var model = await _context.movies
                                .Include(m => m.Genres)
                                .ThenInclude(m => m.Genre)
                                .Include(x => x.Actors)
                                .ThenInclude(x => x.Actor)
                                .Include(k => k.Director)
                                .ToListAsync();

            ViewBag.genres= new SelectList(_context.genres, "GenreId", "Name");
            
            ViewBag.result = "All";

            if (!String.IsNullOrEmpty(filter))
            {
                model = await _context.movies
                              .Include(m => m.Genres)
                              .ThenInclude(x => x.Genre)
                              .Include(k => k.Actors)
                              .ThenInclude(k => k.Actor)
                              .Include(k => k.Director)
                              .Where(k => k.Genres.Any(x => x.GenreId.ToString() == filter)).ToListAsync();
                            var filterString = _context.genres.FirstOrDefault(x => x.GenreId.ToString() == filter);
                            ViewBag.result = $"Genre: {filterString?.Name}";

            }

            if (searchString != null)
            {
                model = await _context.movies
                              .Include(m => m.Genres)
                              .ThenInclude(x => x.Genre)
                              .Include(k => k.Actors)
                              .ThenInclude(k => k.Actor)
                              .Include(k => k.Director)
                              .Where(k => k.MovieTitle!.ToLower().Contains(searchString.ToLower())).ToListAsync();

                ViewBag.search = searchString;
            }

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Actors = new SelectList(_context.actors, "ActorId", "FirstName");
            ViewBag.Directors = new SelectList(_context.directors, "DirectorId", "FirstName");
            ViewBag.genres = new SelectList(_context.genres, "GenreId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDTO movieDTO, IFormFile? formImg)
        {
            var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (formImg != null)
            {
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
                    movieDTO.MovieImg = fileName;
                }
            }
            // else
            // {
            //     movieDTO.MovieImg = 
            // }

            if (!ModelState.IsValid)
            {
                return View("create", movieDTO);
            }
            var movie = new Movie
            {
                MovieTitle = movieDTO.MovieTitle,
                Description = movieDTO.Description,
                ReleaseDate = movieDTO.ReleaseDate,
                DirectorId = movieDTO.DirectorId,
                MovieImg = movieDTO.MovieImg

            };

            foreach (var item in movieDTO.GenreIds)
            {
                movie.Genres.Add(new MovieGenre { GenreId = item });
            }

            foreach (var item in movieDTO.ActorIds)
            {
                movie.Actors.Add(new MovieActor { ActorId = item });
            }

            await _context.movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Movies", "Management");
        }


        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var Entity = await _context.movies
            .Include(c => c.Actors)
            .ThenInclude(x => x.Actor)
            .Include(c => c.Genres)
            .ThenInclude(x => x.Genre)
            .FirstAsync(x => x.MovieId == id);
            if (Entity != null)
            {

                var DTO = new CreateMovieDTO()
                {
                    MovieTitle = Entity.MovieTitle,
                    Description = Entity.Description,
                    ReleaseDate = Entity.ReleaseDate,
                    DirectorId = Entity.DirectorId,
                    ActorIds = Entity.Actors.Select(k => k.ActorId).ToList(),
                    GenreIds = Entity.Genres.Select(k => k.GenreId).ToList(),
                    MovieImg = Entity.MovieImg


                };

                // ViewBag.SelectedActor = Entity.Actors;

                ViewBag.Actors = new SelectList(_context.actors, "ActorId", "FirstName");
                ViewBag.Directors = new SelectList(_context.directors, "DirectorId", "FirstName");
                ViewBag.genres = new SelectList(_context.genres, "GenreId", "Name");
                return View(DTO);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int? id, CreateMovieDTO editedDTO, IFormFile formImg)
        {

            var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            if (formImg != null)
            {
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
                    editedDTO.MovieImg = fileName;
                }
            }
            else
            {
                var Movie = await _context.movies.FirstOrDefaultAsync(x => x.MovieId == id);
                editedDTO.MovieImg = Movie!.MovieImg;
            }


            if (id != null)
            {

                var Movie = await _context.movies
                        .Include(m => m.Genres)
                        .Include(m => m.Actors)
                        .FirstOrDefaultAsync(x => x.MovieId == id);

                if (id != Movie!.MovieId)
                {
                    return NotFound();
                }


                Movie!.MovieTitle = editedDTO.MovieTitle;
                Movie.Description = editedDTO.Description;
                Movie.ReleaseDate = editedDTO.ReleaseDate;
                Movie.DirectorId = editedDTO.DirectorId;
                Movie.MovieImg = editedDTO.MovieImg;

                Movie.Genres.Clear();
                Movie.Actors.Clear();

                foreach (var item in editedDTO.GenreIds)
                {
                    Movie.Genres.Add(new MovieGenre { GenreId = item });
                }


                foreach (var item in editedDTO.ActorIds)
                {
                    Movie.Actors.Add(new MovieActor { ActorId = item });
                }

                _context.Update(Movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Movies", "Management");
            }

            return NotFound();
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var Entity = await _context.movies.FirstOrDefaultAsync(m => m.MovieId == id);

            return View(Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, Movie movie)
        {

            if (id == movie.MovieId)
            {
                var Entity = await _context.movies.FirstOrDefaultAsync(x => x.MovieId == id);
                _context.movies.Remove(Entity!);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View("Movies", "Management");
        }
    }
}

