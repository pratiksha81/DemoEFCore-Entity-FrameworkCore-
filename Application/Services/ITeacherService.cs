﻿using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITeacherService
    {
        // Add a new teacher
        Task<int> AddTeacherAsync(Teacher teacher);

        // Get a teacher by ID
        Task<Teacher> GetTeacherByIdAsync(int teacherId);

        // Get all teachers
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
    }
}
