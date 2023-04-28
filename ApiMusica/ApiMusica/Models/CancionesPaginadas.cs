using NugetMusica.Models;

namespace ApiMusica.Models {
    public class CancionesPaginadas {
        public List<Cancion> Canciones { get; set; }
        public int NumRegistros { get; set; }
    }
}
