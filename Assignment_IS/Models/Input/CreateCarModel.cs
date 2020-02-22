using System.ComponentModel.DataAnnotations;

namespace Assignment_IS.Models.Input
{
    public class CreateCarModel
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public int Speed { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string CargoType { get; set; }

        [Required]
        public double Tire1Presure { get; set; }

        [Required]
        public int Tire1Age { get; set; }

        [Required]
        public double Tire2Presure { get; set; }

        [Required]
        public int Tire2Age { get; set; }

        [Required]
        public double Tire3Presure { get; set; }

        [Required]
        public int Tire3Age { get; set; }

        [Required]
        public double Tire4Presure { get; set; }

        [Required]
        public int Tire4Age { get; set; }
    }
}
