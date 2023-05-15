/* Javier Suárez Guzmán
 * Mayo 2023 */

using Microsoft.EntityFrameworkCore;

namespace API_tareas.Models
{
    [PrimaryKey(nameof(Nombre))]
    public class Alumno
    {
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Fecha_Nacimiento { get; set; }
        public string? Carrera { get; set; }
    }
}
