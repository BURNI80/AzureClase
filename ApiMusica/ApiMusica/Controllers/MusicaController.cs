using ApiMusica.Repositories;
using NugetMusica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiMusica.Models;

namespace ApiMusica.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase {

        private RepositoryMusica repo;

        public MusicaController(RepositoryMusica repo){
            this.repo=repo;
        }

        //GET ALL
        [HttpGet]
        public async Task<ActionResult<List<Cancion>>> Get()
        {
            return await this.repo.GetCancionesAsync();
        }

        //FIND CANCION
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> FindCancion(int id)
        {
            return await this.repo.FindCancionAsync(id);
        }

        [HttpGet]
        [Route("[action]/{posicion}")]
        public async Task<ActionResult<CancionesPaginadas>> GetCancionesPaginadas(int posicion = 0) {

            CancionesPaginadas cancionesPag = await this.repo.GetCancionesPaginacionAsync(posicion);

            return cancionesPag;
        }

        //GET CANCIONES GENERO
        [HttpGet]
        [Route("[action]/{idGenero}")]
        public async Task<ActionResult<List<Cancion>>> GetCancionesGenero(int idGenero) {
            return await this.repo.GetCancionesGeneroAsync(idGenero);
        }

        //GET GENEROS
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Genero>>> GetGeneros() {
            return await this.repo.GetGenerosAsync();
        }

        //INSERT CANCION
        [HttpPost]
        public async Task<ActionResult> InsertCancion(Cancion cancion){
            await this.repo.InsertCancionAsync(cancion.IdCancion, cancion.Nombre, cancion.Duracion, cancion.Album, cancion.Portada, cancion.IdArtista, cancion.IdGenero);
            return Ok();
        }

        //UPDATE CANCION
        [HttpPut]
        [Route("[action]/{idCancion}/{nombre}/{duracion}/{idGenero}")]
        public async Task<ActionResult> UpdateCancion(int idCancion, string nombre, double duracion, int idGenero){
            await this.repo.UpdateCancionAsync(idCancion, nombre, duracion, idGenero);
            return Ok();
        }

        //DELETE CANCION
        [HttpDelete]
        [Route("[action]/{idCancion}")]
        public async Task<ActionResult> DeleteCancion(int idCancion){
            await this.repo.DeleteCancionAsync(idCancion);
            return Ok();
        }
    }
}
