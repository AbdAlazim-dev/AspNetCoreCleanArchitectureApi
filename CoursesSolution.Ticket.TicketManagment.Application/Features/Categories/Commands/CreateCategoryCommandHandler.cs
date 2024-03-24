using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IAsyncRerository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IAsyncRerository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if(validationResult.Errors.Count > 0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new List<string>();

            foreach(var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
            throw new Exceptions.ValidationException(validationResult);
        }
        if(createCategoryCommandResponse.Success)
        {
            //create an entity out of the request object
            var categoryToCreate = new Category() { Name = request.Name };

            //add the entity to the database
            await _categoryRepository.AddAsync(categoryToCreate);

            //create a response object to return
            createCategoryCommandResponse =
                _mapper.Map<CreateCategoryCommandResponse>(categoryToCreate);
        }

        return createCategoryCommandResponse;
    }
}


