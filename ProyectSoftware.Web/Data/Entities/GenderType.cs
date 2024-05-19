using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class GenderType
    {
        [Key]
        public int Id { get; set; }
        public string GenderName { get; set; }
        public List<HasSongGender> HasSongGender { get; set; }
    }
}
