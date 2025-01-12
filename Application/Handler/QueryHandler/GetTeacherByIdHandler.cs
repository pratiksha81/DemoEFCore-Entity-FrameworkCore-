using Application.Mappers;
using Domain.Entities.DTOs;
using Domain.Query;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handler.QueryHandler
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDTO>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherByIdHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherDTO> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _teacherRepository.GetTeacherByIdAsync(request.TeacherID);
            return profile?.ToDTO();
        }
    }

}
