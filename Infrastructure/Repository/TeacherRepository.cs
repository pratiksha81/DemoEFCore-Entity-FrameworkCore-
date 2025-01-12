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
    }
}
