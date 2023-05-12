/* Javier Suárez Guzmán
 * Mayo 2023 */

namespace API_tareas.Models
{
    public class TareaItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
