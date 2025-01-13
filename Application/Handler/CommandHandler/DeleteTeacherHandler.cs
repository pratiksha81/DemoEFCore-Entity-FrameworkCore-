using Domain.Entities.Command;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handler.CommandHandler
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ITeacherRepository _repository;

        public DeleteTeacherHandler(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            // Call repository to delete the teacher
            return await _repository.DeleteTeacherAsync(request.TeacherID);
        }
    }
}
