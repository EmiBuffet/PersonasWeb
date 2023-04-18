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

8 Metodos para consultar todos las Personas y para consultar una sola persona por ID
        
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

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

9 En vista, para mostrar detalle de una persona:
		@Html.DisplayFor(m => m.nombre)
Para mostrar varias personas, agregar @model IEnumerable<PersonasWeb.Models.Persona>

	<div class="container-lg col-4">
    	@if (Model.Count() > 0)
    	{
       	 <table class="table table-bordered" id="" width="100%" cellspacing="0">
            <thead>
                <tr>
                    <th>@Html.DisplayNameFor(m => m.Id)</th>
                    <th>@Html.DisplayNameFor(m => m.nombre)</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var item in Model)
                {
                    	<tr>
                        	<td>@Html.DisplayFor(m => item.Id)</td>
                        	<td>@Html.DisplayFor(m => item.nombre)</td>
                        	<td>
                            	<a class="btn btn-secondary" asp-action="ConsultarPersona" asp-route-id="@item.Id"><i class="bi bi-info-circle-fill"></i>Detalle</a>
                        	</td>
                    	</tr>
                }
            </tbody>
        </table>
    	}
    	else
   	 {
        	<p>No hay registros</p>
   	 }
	</div>
