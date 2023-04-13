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
        public IActionResult CrearPersona()
        {
            return View();
        }

        // Ejercicio: Crear vista para constar personas, sin parametros
        // Debe mostrar un h2 con el texto "Pantalla para consultar Persona"
        // La misma se debe acceder desde una opcion en el menú
        public IActionResult ConsultarPersona(string nombre)
        {
            ViewData["nombre"] = nombre;
            return View();
        }

        // Recibe dos parametros nombre y apellido
        // Retorna un texto "Nombre: Emiliano, Apellido: Buffet"
        // URL: /Persona/ConsultarPersona?nombre=Emiliano&apellido=Buffet
        /*public string ConsultarPersona(string nombre, string apellido)
        {
            return HtmlEncoder.Default.Encode($"Nombre: {nombre}, Apellido: {apellido}");
        }*/
    }
}
