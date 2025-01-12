
using Application.Mappers;
using Domain.Entities.Command;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handler.CommandHandler
{
    public class AddTeacherHandler : IRequestHandler<AddTeacherCommand, int>
    {
        private readonly ITeacherRepository _repository;

        public AddTeacherHandler(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = request.teacher.ToEntity();
            return await _repository.AddTeacherAsync(entity);
        }
    }
}
