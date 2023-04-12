using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PersonasWeb.Controllers
{
    public class PersonaController : Controller
    {
        // URL: /Persona
        public string Index()
        {
            return "Crear Persona";
        }
        // URL: /Persona/CrearPersona
        public string CrearPersona()
        {
            return "Pantalla para crear personas";
        }

        // Recibe dos parametros nombre y apellido
        // Retorna un texto "Nombre: Emiliano, Apellido: Buffet"
        // URL: /Persona/ConsultarPersona?nombre=Emiliano&apellido=Buffet
        public string ConsultarPersona(string nombre, string apellido)
        {
            return HtmlEncoder.Default.Encode($"Nombre: {nombre}, Apellido: {apellido}");
        }
    }
}
