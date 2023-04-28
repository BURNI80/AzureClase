using Microsoft.AspNetCore.Mvc;
using MvcCrudMusica.Services;
using NugetCrudMusica.Models;

namespace MvcCrudMusica.Controllers {
    public class MusicaController : Controller {

        private ServiceMusica service;

        public MusicaController(ServiceMusica service) {
            this.service = service;
        }

        public async Task<IActionResult> GetArtistas(int posicion = 0, int rango = 0) {
            ArtistasPaginados artistasPaginados = await this.service.GetArtistasPaginadosAsync(posicion, rango);
            ViewBag.NumeroRegistros = artistasPaginados.NumeroRegistros;
            ViewBag.Rango = (rango != 0) ? rango : 2;
            return View(artistasPaginados.Items);
        }

        [HttpPost]
        public async Task<IActionResult> GetArtistas(int rango) {
            ArtistasPaginados artistasPaginados = await this.service.GetArtistasPaginadosAsync(0, rango);
            ViewBag.NumeroRegistros = artistasPaginados.NumeroRegistros;
            ViewBag.Rango = (rango != 0) ? rango : 2;
            return View(artistasPaginados.Items);
        }


        public IActionResult CreateArtista() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtista(Artista artista) {
            await this.service.InsertArtistaAsync(artista);
            return RedirectToAction("GetArtistas");
        }
        
        
        public async Task<IActionResult> UpdateArtista(int idArtista) {
            Artista? artista = await this.service.FindArtistaAsync(idArtista);
            return View(artista);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArtista(Artista artista) {
            await this.service.UpdateArtistaAsync(artista);
            return RedirectToAction("GetArtistas");
        }


        public async Task<IActionResult> DeleteArtista(int idArtista) {
            await this.service.DeleteArtistaAsync(idArtista);
            return RedirectToAction("GetArtistas");
        }

    }
}
