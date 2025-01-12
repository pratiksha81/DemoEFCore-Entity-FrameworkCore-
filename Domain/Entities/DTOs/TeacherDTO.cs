using System;

namespace Domain.Entities.DTOs
{
    public class TeacherDTO
    {
        public int TeacherID { get; set; } // ID of the teacher

        public string Name { get; set; } // Name of the teacher

        public string Qualification { get; set; } // Qualification details

        public string Experience { get; set; } // Experience in years or description

        public string Email { get; set; } // Email address

        public DateTime? DoB { get; set; } // Date of Birth (optional)

        public string Gender { get; set; } // Gender

        public string PhoneNo { get; set; } // Contact phone number
    }
}
