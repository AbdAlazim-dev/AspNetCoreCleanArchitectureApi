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

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Queries.GetCourseDetails;

public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, CourseDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRerository<Course> _courseRepository;

    public GetCourseDetailQueryHandler(IMapper mapper,
        IAsyncRerository<Course> courseRepository,
        IAsyncRerository<CourseCategoryDto> categoryRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }
    public async Task<CourseDetailsDto> Handle(GetCourseDetailQuery request,
        CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.Id);
        var courseDetail = _mapper.Map<CourseDetailsDto>(course);

        var category = await _courseRepository.GetByIdAsync(course.CategoryId);
        var categoryDto = _mapper.Map<CourseCategoryDto>(category);

        courseDetail.Category = categoryDto;

        return courseDetail;
    }
}
