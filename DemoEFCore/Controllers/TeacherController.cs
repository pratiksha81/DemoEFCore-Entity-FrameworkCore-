using Application.Mappers;
using Domain.Entities.Command;
using Domain.Entities.DTOs;
using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // For ILogger

namespace DemoEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TeacherController> _logger; // Logger declaration

        public TeacherController(IMediator mediator, ILogger<TeacherController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // POST: api/Teacher/Add
        [HttpPost("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] CreateTeacherDTO insert)
        {
            _logger.LogInformation("Received request to add a new teacher: {InsertData}", insert);
            var id = await _mediator.Send(new AddTeacherCommand(insert));
            _logger.LogInformation("Teacher added successfully with ID: {Id}", id);
            return Ok(id);
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<IActionResult> GetAllTeacherAsync()
        {
            _logger.LogInformation("Received request to retrieve all teachers");
            var profiles = await _mediator.Send(new GetAllTeachersQuery());
            _logger.LogInformation("Successfully retrieved {Count} teacher profiles", profiles?.Count());
            return Ok(profiles);
        }

        // GET: api/Teacher/{id}
        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int teacherId)
        {
            _logger.LogInformation("Received request to retrieve teacher with ID: {TeacherId}", teacherId);
            var getById = await _mediator.Send(new GetTeacherByIdQuery(teacherId));
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
    }
}
