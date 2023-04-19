using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PersonasWeb.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [EnumDataType(typeof(Ciudad))]
        public Ciudad Ciudad { get; set; }
    }

    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2,
        Otro = 3
    }

    public enum Ciudad
    {
        Sunchales = 1,
        Ataliva = 2,
        Rafaela = 3
    }
}
