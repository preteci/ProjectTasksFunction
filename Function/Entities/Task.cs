using Microsoft.EntityFrameworkCore;

namespace Function.Entities
{
    [Owned]
    public class Task
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
