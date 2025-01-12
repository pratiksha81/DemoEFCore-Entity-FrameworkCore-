using Application.Mappers;
using Domain.Entities.Command;
using Domain.Entities.DTOs;
using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Teacher/Add
        [HttpPost("Add")]

        public async Task<IActionResult> AddTeacherAsync([FromBody] CreateTeacherDTO insert)
        {
            var id = await _mediator.Send(new AddTeacherCommand(insert));
            return Ok(id);
        }
        

        // GET: api/Teacher

        [HttpGet]
        public async Task<IActionResult> GetAllTeacherAsync()
        {
            var profiles = await _mediator.Send(new GetAllTeachersQuery());
            return Ok(profiles);
        }

        // GET: api/Teacher/{id}
        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int teacherId)
        {
            var GetById = await _mediator.Send(new GetTeacherByIdQuery(teacherId));
            return GetById != null ? Ok(GetById) : NotFound();
        }


    }
}
