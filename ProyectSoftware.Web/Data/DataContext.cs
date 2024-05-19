using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data.Entities;

namespace ProyectSoftware.Web.Data
{
    public class DataContext : DbContext
    {
     
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configura la relación muchos a muchos usando la tabla de unión AuthorBook.
                modelBuilder.Entity<HasSongGender>()
                    .HasKey(ab => new { ab.IdGender, ab.IdSong });

                modelBuilder.Entity<HasSongPlaylist>()
                    .HasKey(ab => new { ab.IdPlaylist, ab.IdSong });

                modelBuilder.Entity<HasSongUser>()
                        .HasKey(ab => new { ab.IdSong, ab.IdUser });

        }

        public DbSet<Author> Authors { get; set; }
            public DbSet<GenderType> GenderTypes { get; set; }
            public DbSet<Playlist> Playlists { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Song> Songs { get; set; }
            public DbSet<HasSongGender> HasSongsGenders { get; set; }
            public  DbSet<HasSongPlaylist> hasSongPlaylists { get; set; }
            public DbSet<HasSongUser> hasSongUsers { get; set; }    
    }
}
