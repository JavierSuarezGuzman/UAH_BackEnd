/* Javier Suárez Guzmán
 * Mayo 2023 */

namespace API_tareas.Models

// Las clases de modelo pueden ir en cualquier lugar del proyecto, pero por convención, se usa la carpeta Models .
{
    public class TareaItem
    {
        public long Id { get; set; } // La propiedad Id funciona como clave única en una base de datos relacional.
        public string? Name { get; set; }
        public string? Desc { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}
