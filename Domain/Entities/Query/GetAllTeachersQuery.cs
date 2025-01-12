using Domain.Entities.DTOs;
using MediatR;

namespace Domain.Query
{
    public record GetAllTeachersQuery : IRequest<IEnumerable<TeacherDTO>>;
}
