using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Investor : User
    {
        public List<Project> Projects { get; set; }
    }
}