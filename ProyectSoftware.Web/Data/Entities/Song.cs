using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  int Duracion { get; set; }
     
        public ICollection<HasSongPlaylist> HasSongPlaylists { get; set; }
        public ICollection<HasSongGender> HasSongGenders { get; set; }

        public ICollection<UserSong> UserSongs { get; set; }

    }
}
