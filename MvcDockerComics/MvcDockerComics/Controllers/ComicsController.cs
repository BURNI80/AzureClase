using Microsoft.AspNetCore.Mvc;
using MvcDockerComics.Models;
using MvcDockerComics.Repositories;

namespace MvcDockerComics.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await this.repo.GetComicsAsync();
            return View(comics);
        }

        public async Task<IActionResult> Details(int id)
        {
            Comic comic = await this.repo.FindComicAsync(id);
            return View(comic);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await this.repo.InsertComicAsync(comic.Nombre, comic.Imagen);
            return RedirectToAction("Index");
        }
    }

}
