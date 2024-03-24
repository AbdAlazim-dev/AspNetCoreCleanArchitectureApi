using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    private readonly ICourseRerpository _courseRerpository;
    public CreateCourseCommandValidator()
    {
        //Name property should not be empty or null or exceed 50 characters
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        //Date property should not be empty or null or lowert then todays date
        RuleFor(c => c.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now).WithMessage("{PropertyName} should be greater than today's date.");
        //Price should not be empty or null or less then 0 there is no free courses
        RuleFor(c => c.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("You can not create a free course in this website");

        //Create custom validation for the course name and date
        RuleFor(c => c)
            //Check if the course name and date are unique
            .MustAsync(CourseNameAndDateUniq)
            .WithMessage("A course with the same name and date already exists.");
    }
    private async Task<bool> CourseNameAndDateUniq(CreateCourseCommand request ,CancellationToken cancellationToken)
    {
        return !(await _courseRerpository.IsCourseNameAndDateUniq(request.Name, request.Date));
    }
}
