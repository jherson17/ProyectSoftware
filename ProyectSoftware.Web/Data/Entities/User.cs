using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public string Password { get; set; }
        [Display(Name = "Age")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Range(18, 120, ErrorMessage = "La edad debe estar entre {1} y {2}.")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public List<HasSongUser> HasSongUser { get; set; }

    }
}
