using Domain.Entities.DTOs;
using Domain.Entities.Models;

namespace Application.Mappers
{
    public static class TeacherMapper
    {
        // Convert Teacher to TeacherDTO
        public static TeacherDTO ToDTO(this Teacher teacher)
        {
            return new TeacherDTO
            {
                TeacherID = teacher.TeacherID,
                Name = teacher.Name,
                Qualification = teacher.Qualification,
                Experience = teacher.Experience,
                Email = teacher.Email,
                DoB = teacher.DoB,
                Gender = teacher.Gender,
                PhoneNo = teacher.PhoneNo
            };
        }


        // Convert TeacherDTO to Teacher
        public static Teacher ToEntity(this CreateTeacherDTO teacherDTO)
        {
            return new Teacher
            {
              
                Password= teacherDTO.Password,
                Name = teacherDTO.Name,
                Qualification = teacherDTO.Qualification,
                Experience = teacherDTO.Experience,
                Email = teacherDTO.Email,
                DoB = teacherDTO.DoB,
                Gender = teacherDTO.Gender,
                PhoneNo = teacherDTO.PhoneNo
            };


        }
    }
}
