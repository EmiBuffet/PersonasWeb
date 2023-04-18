using System.ComponentModel.DataAnnotations;

namespace PersonasWeb.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
