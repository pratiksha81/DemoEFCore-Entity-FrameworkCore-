using Application.Validators;
using Domain.Entities.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Domain.Entities.Command;
using Domain.Query;

namespace DemoEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : BaseApiController
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IValidator<UpdateTeacherDTO> _updateTeacherValidator;

        public TeacherController(IMediator mediator, ILogger<TeacherController> logger, IValidator<UpdateTeacherDTO> updateTeacherValidator)
        {
            _logger = logger;
            _updateTeacherValidator = updateTeacherValidator;
        }


        // POST: api/Teacher/Add
        [HttpPost("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] CreateTeacherDTO insert)
        {
            _logger.LogInformation("Received request to add a new teacher: {InsertData}", insert);
            var id = await Mediator.Send(new AddTeacherCommand(insert));
            _logger.LogInformation("Teacher added successfully with ID: {Id}", id);
            return Ok(id);
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<IActionResult> GetAllTeacherAsync()
        {
            _logger.LogInformation("Received request to retrieve all teachers");
            var profiles = await Mediator.Send(new GetAllTeachersQuery());
            _logger.LogInformation("Successfully retrieved {Count} teacher profiles", profiles?.Count());
            return Ok(profiles);
        }

        // GET: api/Teacher/{id}
        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int teacherId)
        {
            _logger.LogInformation("Received request to retrieve teacher with ID: {TeacherId}", teacherId);
            var getById = await Mediator.Send(new GetTeacherByIdQuery(teacherId));
            if (getById != null)
            {
                _logger.LogInformation("Successfully retrieved teacher with ID: {TeacherId}", teacherId);
                return Ok(getById);
            }
            else
            {
                _logger.LogWarning("Teacher with ID: {TeacherId} not found", teacherId);
                return NotFound();
            }
        }



        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeacherAsync([FromBody] UpdateTeacherDTO updateTeacher)
        {
            var validationResult = await _updateTeacherValidator.ValidateAsync(updateTeacher);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for update teacher: {Errors}", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
                return BadRequest(validationResult.Errors);
            }

            // Proceed with the update logic
            var result = await Mediator.Send(new UpdateTeacherCommand(updateTeacher));
            if (result)
            {
                _logger.LogInformation("Teacher with ID {TeacherID} successfully updated", updateTeacher.TeacherID);
                return Ok();
            }
            else
            {
                _logger.LogWarning("Teacher with ID {TeacherID} not found or update failed", updateTeacher.TeacherID);
                return NotFound();
            }
        }


        // DELETE: api/Teacher/{id}
        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacherAsync(int teacherId)
        {
            // Send request to delete the teacher
            var result = await Mediator.Send(new DeleteTeacherCommand(teacherId));

            if (result)
            {
                _logger.LogInformation("Teacher with ID {TeacherID} successfully deleted", teacherId);
                return Ok(new { message = "Teacher deleted successfully." });
            }
            else
            {
                _logger.LogWarning("Teacher with ID {TeacherID} not found or deletion failed", teacherId);
                return NotFound(new { message = "Teacher not found." });
            }
        }


    }
}
