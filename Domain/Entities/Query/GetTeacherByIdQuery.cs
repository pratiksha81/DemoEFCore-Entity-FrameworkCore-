using Domain.Entities.DTOs;
using MediatR;

namespace Domain.Query
{

    public record GetTeacherByIdQuery(int TeacherID) : IRequest<TeacherDTO>;
}
