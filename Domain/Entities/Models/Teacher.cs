using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; } // Primary Key, Not Null

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

        //[ForeignKey("UploadImg")]
        //public int? UploadImgID { get; set; } // Foreign Key, Nullable

        // Navigation property (optional)
       // public virtual UploadImg UploadImg { get; set; }

        //[NotMapped]
        //public int TotalTeacher { get; set; } // Computed/Derived property, not mapped to the database
    }
}

