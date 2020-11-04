using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Cars
{
    public class CarUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public string Number { get; set; }
        public double Mileage { get; set; }
        public double Fuel_consumption { get; set; }
    }
}
