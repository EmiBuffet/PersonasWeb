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

	builder.Services.AddDbContext<PersonasWebContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("PersonasWebContext")));
      
4 En el archivo appsetting.json, agregar la conexion a la base de datos

	"ConnectionStrings": 
	{ "PersonasWebContext": "Server=localhost\\SQLEXPRESS;Database=Personas;Trusted_Connection=True;MultipleActiveResultSets=true;IntegratedSecurity=True;TrustServerCertificate=True;" }
  
5 Ejercutar : Add-Migration InitialCreate y Update-Database  

6 En el controlador creado agregar

	private readonly PersonasWebContext _context;

        public PersonaController(PersonasWebContext context)
        {
            _context = context;
        }
        //Metodo post
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
7 En archivo .csthml

	@model PersonasWeb.Models.Persona
	@{
    	ViewData["Title"] = "Crear Personas";
	}
	
	<div class="container-lg col-4">
    	<h1>Registrar Persona</h1>
    	<form asp-action="CrearPersona" method="POST">
	<div class="input-group mb-3">
            	<label asp-for="Nombre" class="input-group-text">Nombre</label>
            	<input asp-for="Nombre" type="text" class="form-control" placeholder="Ingresar Nombre" id="nombre">
        </div>
        	<button type="submit" class="btn btn-primary">Guardar</button>
    	</form>
	</div>
