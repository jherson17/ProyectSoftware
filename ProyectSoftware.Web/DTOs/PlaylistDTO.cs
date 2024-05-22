using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.DTOs
{
    public class PlaylistDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Cantidad { get; set; }
    }
}
