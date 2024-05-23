using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Author
    {
        [Key]
        [Display(Name = "Author")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string StageName { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [MaxLength(64, ErrorMessage = "El campo '{0}' debe terner máximo {1} caractéres")]
        public string LastName { get; set; }
    }
}
