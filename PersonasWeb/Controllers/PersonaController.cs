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

        // URL: /Persona/ConsultarPersona?parametro=
        public string ConsultarPersona(string parametro)
        {
            return HtmlEncoder.Default.Encode($"{parametro}");
        }

        //Modificar el metodo ConsultarPersona para que reciba dos parametros: nombre y apellido
        //Y luego mostrar "Nombre: Emiliano, Apellido: Buffet"
    }
}
