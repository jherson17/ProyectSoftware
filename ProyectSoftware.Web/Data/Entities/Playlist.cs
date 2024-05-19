using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }     
        public int Cantidad { get; set;}
        public List<HasSongPlaylist> HasSongPlaylist { get; set; }
    }
}
