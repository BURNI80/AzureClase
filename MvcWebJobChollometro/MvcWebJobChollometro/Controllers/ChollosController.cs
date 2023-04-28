using Microsoft.AspNetCore.Mvc;
using MvcWebJobChollometro.Models;
using MvcWebJobChollometro.Repositoris;

namespace MvcWebJobChollometro.Controllers
{
    public class ChollosController : Controller
    {
        private RepositoryChollometro repo;

        public ChollosController(RepositoryChollometro repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Chollo> chollos = await this.repo.GetChollosAsync();
            return View(chollos);
        }
    }
}
