using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Trailers
{
    public class TrailerCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
