using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DTOs
{
    public class CreateTeacherDTO
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } // Not Null

        [Required]
        [MaxLength(255)]
        public string Qualification { get; set; } // Not Null

        [Required]
        [MaxLength(255)]
        public string Experience { get; set; } // Not Null

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } // Not Null

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } // Not Null

        public DateTime? DoB { get; set; } // Nullable

        [Required]
        [MaxLength(255)]
        public string Gender { get; set; } // Not Null

        [Required]
        [MaxLength(255)]
        [Phone]
        public string PhoneNo { get; set; } // Not Null
    }
}
