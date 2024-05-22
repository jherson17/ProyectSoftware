using ProyectSoftware.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string StageName { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string LastName { get; set; }

        public List<Song> Songs { get; set; }
    }
}
