using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core
{
    public class Investor : User
    {
        [JsonIgnore]
        public List<Project> Projects { get; set; }
    }
}