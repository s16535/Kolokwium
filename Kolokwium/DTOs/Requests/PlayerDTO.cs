using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs.Requests
{
    public class PlayerDTO
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public int NumOnShirt { get; set; }
        [MaxLength(300)]
        public DateTime DateOfBirth { get; set; }
        public string Comment { get; set; }
    }
}
