using Application.Mappers;
using Domain.Entities.DTOs;
using Domain.Entities.Models;
using Infrastructure.Migrations;
using Infrastructure.Repository;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // Add a new teacher
        public async Task<int> AddTeacherAsync(Teacher teacher)
        {
            // Map DTO to entity
            return await _teacherRepository.AddTeacherAsync(teacher);
        }

        // Get a teacher by ID
        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherByIdAsync(teacherId);
        }

        // Get all teachers
        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await _teacherRepository.GetAllTeacherAsync();

        }


        // Update an existing teacher
        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            // Check if the teacher exists
            var existingTeacher = await _teacherRepository.GetTeacherByIdAsync(teacher.TeacherID);
            if (existingTeacher == null)
                return false;

            

            // Call repository method to save changes
            return await _teacherRepository.UpdateTeacherAsync(existingTeacher);
        }

        // Delete a teacher by ID
        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            // Check if the teacher exists
            var existingTeacher = await _teacherRepository.GetTeacherByIdAsync(teacherId);
            if (existingTeacher == null)
                return false;

            // Call repository method to delete the teacher
            return await _teacherRepository.DeleteTeacherAsync(teacherId);
        }
    }
}
