/* Javier Suárez Guzmán
 * Mayo 2023 */

using Microsoft.EntityFrameworkCore;
namespace API_tareas.Models;

public class TareaContext : DbContext
{
    public TareaContext(DbContextOptions<TareaContext> options)
        : base(options)
    {
    }

    public DbSet<TareaItem> TareaItems { get; set; } = null!;
}