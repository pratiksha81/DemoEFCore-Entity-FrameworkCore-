using Domain.Entities.DTOs;
using MediatR;

namespace Domain.Entities.Command
{
    public record AddTeacherCommand(CreateTeacherDTO teacher) : IRequest<int>;
}
