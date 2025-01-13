using Domain.Entities.DTOs;
using Domain.Entities.Models;
using Infrastructure.Data;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _dbContext;

        public TeacherRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add a new teacher
        public async Task<int> AddTeacherAsync(Teacher teacher)
        {

            _dbContext.Teachers.Add(teacher);
            await _dbContext.SaveChangesAsync();
            return teacher.TeacherID;
        }

        // Get a teacher by ID
        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherID == teacherId);//first ko value fetch garna ko lagi
        }

        // Get all teachers
        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await _dbContext.Teachers.ToListAsync();// db table ko sabai value retrive garna ko lai that is ef core
        }

        // Update an existing teacher
        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            var existingTeacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherID == teacher.TeacherID);
            if (existingTeacher == null)
            {
                return false;
            }

            // Update fields
            existingTeacher.Name = teacher.Name;
            existingTeacher.Qualification = teacher.Qualification;
            existingTeacher.Experience = teacher.Experience;
            existingTeacher.Email = teacher.Email;
            existingTeacher.Password = teacher.Password;
            existingTeacher.DoB = teacher.DoB;
            existingTeacher.Gender = teacher.Gender;
            existingTeacher.PhoneNo = teacher.PhoneNo;

            _dbContext.Teachers.Update(existingTeacher);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Delete a teacher by ID
        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherID == teacherId);
            if (teacher == null)
            {
                return false;
            }

            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
