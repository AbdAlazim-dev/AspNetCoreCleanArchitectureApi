using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
{
    private readonly IAsyncRerository<Course> _courseRepository;
    private readonly IMapper _mapper;
    public UpdateCourseCommandHandler(IAsyncRerository<Course> courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseToUpdate = await _courseRepository.GetByIdAsync(request.CourseId);

        _mapper.Map(courseToUpdate, _mapper.Map<Course>(request));

        await _courseRepository.UpdateAsync(courseToUpdate);

    }
}
