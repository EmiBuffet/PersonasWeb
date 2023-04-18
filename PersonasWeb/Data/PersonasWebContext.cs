using Microsoft.EntityFrameworkCore;

public class PersonasWebContext : DbContext
{
    public PersonasWebContext(DbContextOptions<PersonasWebContext> options) : base(options)
    {
    }

    public DbSet<PersonasWeb.Models.Persona> Persona { get; set; } = default!;
}