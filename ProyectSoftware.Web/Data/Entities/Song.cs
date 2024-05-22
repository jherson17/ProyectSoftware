using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProyectSoftware.Web.Models;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duracion { get; set; }
        public List<HasSongGender> HasSongGender { get; set; }
        public List<HasSongPlaylist> HasSongPlaylist { get; set; }
        public List<HasSongUser> HasSongUser { get; set; }
        public Author Author { get; set; }
    }
}

