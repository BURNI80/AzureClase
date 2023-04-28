using ApiMusica.Data;
using ApiMusica.Models;
using Microsoft.EntityFrameworkCore;
using NugetMusica.Models;

namespace ApiMusica.Repositories {
    public class RepositoryMusica {
        private MusicaContext context;

        public RepositoryMusica(MusicaContext context)
        {
            this.context = context;
        } 

        //GET CANCIONES (PARA EL FINAL PAGINAR)
        public async Task<List<Cancion>> GetCancionesAsync()
        {
            return await this.context.Canciones.ToListAsync();
        }

        //GET CANCIONES PAGINADAS
        public async Task<CancionesPaginadas> GetCancionesPaginacionAsync(int posicion) { 
            List<Cancion> canciones = await this.GetCancionesAsync();
            int numRegistros = canciones.Count();

            List<Cancion> listacancionespag = canciones.Skip(posicion).Take(4).ToList();

            CancionesPaginadas cancionesPag = new CancionesPaginadas {
                Canciones = listacancionespag,
                NumRegistros = numRegistros
            };


            return cancionesPag;
        }

        //FIND CANCIUON
        public async Task<Cancion> FindCancionAsync(int idCancion)
        {
            return await this.context.Canciones.FirstOrDefaultAsync(x => x.IdCancion == idCancion);
        }

        //GET CANCIONES GENERO
        public async Task<List<Cancion>> GetCancionesGeneroAsync(int idGenero)
        {
            return await this.context.Canciones.Where(x => x.IdGenero == idGenero).ToListAsync();
        }

        //GET GENEROS
        public async Task<List<Genero>> GetGenerosAsync()
        {
            return await this.context.Generos.ToListAsync();
        }

        //INSERT CANCION
        public async Task InsertCancionAsync(int idCancion, string nombre, double duracion, string album, string portada, int idArtista, int idGenero) {
            Cancion cancion = new Cancion();
            cancion.IdCancion = idCancion;
            cancion.Nombre = nombre;
            cancion.Duracion = duracion;
            cancion.Album = album;
            cancion.Portada = portada;
            cancion.IdArtista = idArtista;
            cancion.IdGenero= idGenero;
            this.context.Canciones.Add(cancion);
            await this.context.SaveChangesAsync();
        }

        //UPDATE CANCION
        public async Task UpdateCancionAsync(int idCancion, string nombre, double duracion, int idGenero) {
            Cancion cancion = await this.FindCancionAsync(idCancion);

            cancion.Nombre = nombre;
            cancion.Duracion = duracion;
            cancion.IdGenero = idGenero;

            await this.context.SaveChangesAsync();
        }

        //DELETE CANCION
        public async Task DeleteCancionAsync(int idCancion){
            Cancion cancion = await this.FindCancionAsync(idCancion);
            this.context.Canciones.Remove(cancion);
            await this.context.SaveChangesAsync();
        }
    }
}
