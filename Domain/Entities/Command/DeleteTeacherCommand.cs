using MediatR;

namespace Domain.Entities.Command
{
    public record DeleteTeacherCommand(int TeacherID) : IRequest<bool>;
}
