using System.ComponentModel.DataAnnotations;

namespace MvcCoreTutorial.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; }
       [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description  { get; set; }
       
    }
}
