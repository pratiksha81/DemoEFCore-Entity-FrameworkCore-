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
    }
}
