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
        public List<HasSongGender> HasSongGenders { get; set; }
        public List<HasSongPlaylist> HasSongPlaylists { get; set; }

        public Author Authors { get; set; }

    }
}
