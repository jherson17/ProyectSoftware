using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        public string StageName { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string LastName { get; set; }
    }
}
