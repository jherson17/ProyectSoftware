using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data.Entities;
using static System.Collections.Specialized.BitVector32;

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


            modelBuilder.Entity<HasSongGender>()
                .HasOne(hsg => hsg.Song)
                .WithMany(s => s.HasSongGender)
                .HasForeignKey(hsg => hsg.IdSong);

            modelBuilder.Entity<HasSongGender>()
                .HasOne(hsg => hsg.GenderType)
                .WithMany(gt => gt.HasSongGender)
                .HasForeignKey(hsg => hsg.IdGender);

            modelBuilder.Entity<HasSongPlaylist>()
                .HasOne(hsg => hsg.Song)
                .WithMany(s => s.HasSongPlaylist)
                .HasForeignKey(hsg => hsg.IdSong);

            modelBuilder.Entity<HasSongPlaylist>()
                .HasOne(hsg => hsg.Playlist)
                .WithMany(gt => gt.HasSongPlaylist)
                .HasForeignKey(hsg => hsg.IdPlaylist);

            modelBuilder.Entity<HasSongUser>()
                .HasOne(hsg => hsg.Song)
                .WithMany(s => s.HasSongUser)
                .HasForeignKey(hsg => hsg.IdSong);

            modelBuilder.Entity<HasSongUser>()
                .HasOne(hsg => hsg.User)
                .WithMany(gt => gt.HasSongUser)
                .HasForeignKey(hsg => hsg.IdUser);


                ConfigureIndexes(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

      
        private void ConfigureIndexes(ModelBuilder modelBuilder)//index es una retriccion que tendra mi tabla de base de datos
        {
            // Sections
            modelBuilder.Entity<Author>()
                        .HasIndex(s => s.StageName)
                        .IsUnique();
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
