using Microsoft.EntityFrameworkCore;
using PersonasWeb.Models;
using System.Reflection.Metadata;

public class PersonasWebContext : DbContext
{
    public PersonasWebContext(DbContextOptions<PersonasWebContext> options) : base(options)
    {
    }

    public DbSet<PersonasWeb.Models.Persona> Persona { get; set; } = default!;
    public DbSet<PersonasWeb.Models.Ciudad> Ciudad { get; set; } = default!;



}