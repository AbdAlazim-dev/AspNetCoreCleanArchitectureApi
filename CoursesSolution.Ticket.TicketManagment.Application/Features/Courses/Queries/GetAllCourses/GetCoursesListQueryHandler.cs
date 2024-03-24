using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetCoursesListQueryHandler
        : IRequestHandler<GetCoursesListQuery, List<CourseDto>>
    {
        private readonly IAsyncRerository<Course> _repository;
        private readonly IMapper _mapper;

        public GetCoursesListQueryHandler(IAsyncRerository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CourseDto>> Handle(GetCoursesListQuery request,
            CancellationToken cancellationToken)
        {
            var allCourses = (await _repository.ListAllAsync())
                .OrderBy(c => c.Date);

            return _mapper.Map<List<CourseDto>>(allCourses);
        }
    }
}
