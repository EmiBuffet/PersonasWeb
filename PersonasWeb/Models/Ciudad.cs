using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace PersonasWeb.Models
{
    public class Ciudad
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public ICollection<Persona>? Personas { get; set; }
    }
}