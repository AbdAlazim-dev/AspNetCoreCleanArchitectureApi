using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly IAsyncRerository<Course> _courseRepository;
    private readonly IMapper _mapper;

    public DeleteCourseCommandHandler(IAsyncRerository<Course> courseRerpository, IMapper mapper)
    {
        _courseRepository = courseRerpository;
        _mapper = mapper;
    }
    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var courseToDelete = await _courseRepository.GetByIdAsync(request.CourseId);

        await _courseRepository.DeleteAsync(courseToDelete);
    }
}
