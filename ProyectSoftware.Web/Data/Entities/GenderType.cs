using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class GenderType
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Range(18, 120, ErrorMessage = "La edad debe estar entre {1} y {2}.")]
        public int Id { get; set; }

        [Display(Name ="GenderType")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string GenderName { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public List<HasSongGender> HasSongGenders { get; set; }
    }
}
