# PersonasWeb
Pasos para usar EntityFramework

Documentacion: https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-6.0&tabs=visual-studio

1 Agregar paquete Nuget
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
2 Agregar carpeta Data, crear clase ApplicationDbContext que herede de DbContext.
    public class PersonasWebContext : DbContext
    {
        public PersonasWebContext (DbContextOptions<PersonasWebContext> options): base(options)
        {
        }

        public DbSet<PersonasWeb.Models.Persona> Persona { get; set; } = default!;
    }
3 En clase program.cs, agregar las siguientes lineas:
  builder.Services.AddDbContext<PersonasContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("PersonasContext") ?? throw new InvalidOperationException("Connection string 'PersonasWebContext' not found.")));
4 En el archivo appsetting.json, agregar la conexion a la base de datos
  "ConnectionStrings": {
    "PersonasWebContext": "Server=(localdb)\\mssqllocaldb;Database=Personas;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
5 Ejercutar : Add-Migration InitialCreate y Update-Database
6 En el controlador creado agregar
        private readonly PersonasContext _context;

        public PersonasController(PersonasWebContext context)
        {
            _context = context;
        }
        //Metodo post
        [HttpPost]
        public async Task<IActionResult> CrearPersona([Bind("Id,nombre,apellido")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }
7 En archivo .csthml
  @model Persona.Models.Persona
  <form asp-action="CrearPersona" method="POST">
  <input asp-for="nombre">
  <label asp-for="nombre">
