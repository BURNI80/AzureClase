using Newtonsoft.Json;
using NugetCrudMusica.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCrudMusica.Services {
    public class ServiceMusica {

        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApi;

        public ServiceMusica(IConfiguration configuration) {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiMusica");
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        #region GENERAL
        private async Task<T> CallApiAsync<T>(string request) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                HttpResponseMessage response = await client.GetAsync(request);
                return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<T>() : default(T);
            }
        }

        private async Task<HttpStatusCode> InsertApiAsync<T>(string request, T objeto) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                return response.StatusCode;
            }
        }
        
        private async Task<HttpStatusCode> UpdateApiAsync<T>(string request, T objeto) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                string json = JsonConvert.SerializeObject(objeto);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);
                return response.StatusCode;
            }
        }
        
        // Se supone que en el request ya va el id. Ejemplo: http:/localhost/api/deletealgo/17
        private async Task<HttpStatusCode> DeleteApiAsync(string request) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage response = await client.DeleteAsync(request);
                return response.StatusCode;
            }
        }
        #endregion

        #region ARTISTAS
        public async Task<List<Artista>?> GetArtistasAsync() {
            string request = "/api/artistas";
            List<Artista>? artistas = await this.CallApiAsync<List<Artista>?>(request);
            return artistas;
        }

        public async Task<ArtistasPaginados> GetArtistasPaginadosAsync(int posicion, int rango = 0) {
            string request = "/api/artistas/getartistaspaginados/" + posicion;
            if (rango != 0) {
                request += "/" + rango;
            }
            ArtistasPaginados artistasPaginados = await this.CallApiAsync<ArtistasPaginados>(request);
            return artistasPaginados;
        }

        public async Task<Artista?> FindArtistaAsync(int idArtista) {
            string request = "/api/artistas/findartista/" + idArtista;
            Artista? artista = await this.CallApiAsync<Artista?>(request);
            return artista;
        }

        public async Task<HttpStatusCode> InsertArtistaAsync(Artista artista) {
            string request = "/api/artistas/insertartista";
            return await this.InsertApiAsync<Artista>(request, artista);
        }

        public async Task<HttpStatusCode> UpdateArtistaAsync(Artista artista) {
            string request = "/api/artistas/updateartista";
            return await this.UpdateApiAsync<Artista>(request, artista);
        }

        public async Task<HttpStatusCode> DeleteArtistaAsync(int idArtista) {
            string request = "/api/artistas/deleteartista/" + idArtista;
            return await this.DeleteApiAsync(request);
        }
        #endregion

        #region CANCIONES
        public async Task<List<Cancion>?> GetCancionesAsync() {
            string request = "/api/canciones";
            List<Cancion>? canciones = await this.CallApiAsync<List<Cancion>?>(request);
            return canciones;
        }

        public async Task<Cancion?> FindCancionAsync(int idCancion) {
            string request = "/api/canciones/" + idCancion;
            Cancion? cancion = await this.CallApiAsync<Cancion?>(request);
            return cancion;
        }

        public async Task<HttpStatusCode> InsertCancionAsync(Cancion cancion) {
            string request = "/api/canciones/insertcancion";
            return await this.InsertApiAsync<Cancion>(request, cancion);
        }

        public async Task<HttpStatusCode> UpdateCancionAsync(Cancion cancion) {
            string request = "/api/canciones/updatecancion";
            return await this.UpdateApiAsync<Cancion>(request, cancion);
        }

        public async Task<HttpStatusCode> DeleteCancionAsync(int idCancion) {
            string request = "/api/canciones/deletecancion/" + idCancion;
            return await this.DeleteApiAsync(request);
        }
        #endregion

        #region GÉNEROS
        public async Task<List<Genero>?> GetGenerosAsync() {
            string request = "/api/generos";
            List<Genero>? generos = await this.CallApiAsync<List<Genero>?>(request);
            return generos;
        }

        public async Task<Genero?> FindGeneroAsync(int idGenero) {
            string request = "/api/generos/" + idGenero;
            Genero? genero = await this.CallApiAsync<Genero?>(request);
            return genero;
        }

        public async Task<HttpStatusCode> InsertGeneroAsync(Genero genero) {
            string request = "/api/generos/insertgenero";
            return await this.InsertApiAsync<Genero>(request, genero);
        }

        public async Task<HttpStatusCode> UpdateGeneroAsync(Genero genero) {
            string request = "/api/generos/updategenero";
            return await this.UpdateApiAsync<Genero>(request, genero);
        }

        public async Task<HttpStatusCode> DeleteGeneroAsync(int idGenero) {
            string request = "/api/generos/deletegenero/" + idGenero;
            return await this.DeleteApiAsync(request);
        }
        #endregion

    }
}
