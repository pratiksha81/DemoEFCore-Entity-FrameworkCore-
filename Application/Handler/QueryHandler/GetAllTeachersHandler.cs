using Application.Mappers;
using Domain.Entities.DTOs;
using Domain.Query;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handler.QueryHandler
{
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<TeacherDTO>>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetAllTeachersHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<TeacherDTO>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {

            var teachers = await _teacherRepository.GetAllTeacherAsync();
            return teachers.Select(p => p.ToDTO());
            
        }
    }
}
