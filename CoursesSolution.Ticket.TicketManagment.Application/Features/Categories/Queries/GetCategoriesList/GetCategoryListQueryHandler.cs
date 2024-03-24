using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListDto>>
{
    private readonly IAsyncRerository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryListQueryHandler(IAsyncRerository<Category> categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<List<CategoryListDto>> Handle(GetCategoryListQuery request,
        CancellationToken cancellationToken)
    {
        var category = (await _categoryRepository.ListAllAsync()).OrderBy(c => c.Name);

        return _mapper.Map<List<CategoryListDto>>(category);
    }
}
