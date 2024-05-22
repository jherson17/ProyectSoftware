using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Models;

namespace ProyectSoftware.Web.Data
{
    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // No es necesario agregar lógica adicional en el constructor en este caso.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la relación muchos a muchos usando la tabla de unión
            modelBuilder.Entity<HasSongGender>()
                .HasKey(ab => new { ab.IdGender, ab.IdSong });

            modelBuilder.Entity<HasSongPlaylist>()
                .HasKey(ab => new { ab.IdPlaylist, ab.IdSong });

            modelBuilder.Entity<HasSongUser>()
                    .HasKey(ab => new { ab.IdSong, ab.IdUser });

            base.OnModelCreating(modelBuilder);
        }

            public DbSet<Author> Authors { get; set; }
            public DbSet<GenderType> GenderTypes { get; set; }
            public DbSet<Playlist> Playlists { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Song> Songs { get; set; }
            public DbSet<HasSongGender> HasSongsGenders { get; set; }
            public  DbSet<HasSongPlaylist> HasSongPlaylists { get; set; }
            public DbSet<HasSongUser> HasSongUsers { get; set; }    
    }
}
