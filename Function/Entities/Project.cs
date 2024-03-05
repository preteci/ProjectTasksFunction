using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using DataTask = Function.Entities.Task;

namespace Function.Entities
{
    public class Project
    {
        [Key]
        [JsonProperty("id")]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DataTask> Tasks { get; set; } = new List<DataTask>();
    }
}
