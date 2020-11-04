using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.BorderCrossings
{
    public class BorderCrossingCreateDto
    {
        public enum Borders
        {
            Украина,
            Россия
        }

        [Required]
        public string Name { get; set; }
        public Borders Border { get; set; }
        public string Location { get; set; }
    }
}
