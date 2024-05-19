using System.ComponentModel.DataAnnotations;

namespace ProyectSoftware.Web.Data.Entities
{
    public class Author
    {
        [Key]
        public string StageName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
