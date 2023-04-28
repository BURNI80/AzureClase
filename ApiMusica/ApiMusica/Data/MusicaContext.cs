using NugetMusica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMusica.Data {
    public class MusicaContext: DbContext {

        public MusicaContext(DbContextOptions<MusicaContext> options) : base(options) {}

        public DbSet<Cancion> Canciones {get; set;}
        public DbSet<Genero> Generos {get; set;}
        public DbSet<Artista> Artistas {get; set;}

    }
}
