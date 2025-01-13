using Domain.Entities.DTOs;
using MediatR;

namespace Domain.Entities.Command
{
    public record UpdateTeacherCommand(UpdateTeacherDTO teacher) : IRequest<bool>;
}
