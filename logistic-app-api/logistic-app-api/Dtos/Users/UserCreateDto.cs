using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Users
{
    public class UserCreateDto
    {
        public enum Position
        {
            Admin,
            Driver
        }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public Position User_position { get; set; }
    }
}
