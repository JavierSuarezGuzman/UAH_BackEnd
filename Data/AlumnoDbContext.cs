/* Javier Suárez Guzmán 
 * Mayo 2023 */

using API_tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_tareas.Models;

    public class AlumnoDbContext : DbContext
    {
        public AlumnoDbContext(DbContextOptions<AlumnoDbContext> options) 
            : base(options) 
        { 
        }

    public DbSet<Alumno> Alumnos { get; set; } = null!;
    }

