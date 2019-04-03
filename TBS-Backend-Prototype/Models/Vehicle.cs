using System.ComponentModel.DataAnnotations;

namespace TBS_Backend_Prototype.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter a make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter a model")]
        public string Model { get; set; }
    }
}