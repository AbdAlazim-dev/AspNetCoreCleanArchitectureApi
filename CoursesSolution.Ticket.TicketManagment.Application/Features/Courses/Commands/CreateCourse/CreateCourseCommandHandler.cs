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

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly ICourseRerpository _courseRerpository;
    private readonly IMapper _mapper;
    private readonly CreateCourseCommandValidator _courseValidator;
    public CreateCourseCommandHandler(ICourseRerpository courseRerpository, IMapper mapper)
    {
        _courseRerpository = courseRerpository;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseEntity = _mapper.Map<Course>(request);

        var courseValidator = new CreateCourseCommandValidator();
        var validationResult = await courseValidator.ValidateAsync(request);
        
        //check if the request data is valid 
        if(validationResult.Errors.Count > 0)
        {   
            throw new Exceptions.ValidationException(validationResult);
        }

        courseEntity = await _courseRerpository.AddAsync(courseEntity);

        return courseEntity.CourseId;
    }
}
