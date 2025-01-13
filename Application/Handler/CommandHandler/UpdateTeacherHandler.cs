using Application.Mappers;
using Domain.Entities.Command;
using Domain.Entities.Models;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handler.CommandHandler
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly ITeacherRepository _repository;

        public UpdateTeacherHandler(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            // Check if the teacher exists
            var existingTeacher = await _repository.GetTeacherByIdAsync(request.teacher.TeacherID);
            if (existingTeacher == null)
            {
                return false; // Teacher not found
            }

            // Map the updated properties from the request to the existing entity
            var updatedTeacher = request.teacher.ToEntity(existingTeacher); // Assuming `ToEntity` maps the request data to the entity

            // Call repository to update the teacher in the database
            var updated = await _repository.UpdateTeacherAsync(updatedTeacher);

            return updated;
        }
    }
}
