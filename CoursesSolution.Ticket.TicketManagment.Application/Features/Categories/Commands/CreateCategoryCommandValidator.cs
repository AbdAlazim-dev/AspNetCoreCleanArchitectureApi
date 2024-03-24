using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    public CreateCategoryCommandValidator()
    {

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        
    }

    private async Task<bool> BeUniqName(string name, CancellationToken cancellationToken)
    {
        return !(await _categoryRepository.IsCategoryNameUnique(name));
    }
}
