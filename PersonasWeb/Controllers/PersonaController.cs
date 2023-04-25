using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasWeb.Models;
using System.Text.Encodings.Web;

namespace PersonasWeb.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonasWebContext _context;
        public PersonaController(PersonasWebContext context)
        {
            _context = context;
        }
        // URL: /Persona
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persona.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPersona(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.Include(p => p.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }


        // URL: /Persona/CrearPersona
        public async Task<IActionResult> CrearPersonaAsync()
        {
            ViewData["Ciudades"] = await _context.Ciudad.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPersona(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // URL: /Persona/ConsultarPersona?nombre=Emiliano
        // Pasamos del controlador a la vista el parametro nombre
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
