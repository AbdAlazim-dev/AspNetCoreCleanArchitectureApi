using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequest<CreateCourseCommand, Guid>
{
    private readonly ICourseRerpository _courseRerpository;
    private readonly IMapper _mapper;
    public CreateCourseCommandHandler(ICourseRerpository courseRerpository, IMapper mapper)
    {
        _courseRerpository = courseRerpository;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseEntity = _mapper.Map<Course>(request);

        courseEntity = await _courseRerpository.AddAsync(courseEntity);

        return courseEntity.CourseId;
    }
}
