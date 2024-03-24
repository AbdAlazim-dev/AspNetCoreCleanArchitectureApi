using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class GetCategoryListWithCoursesQueryHanlder
    : IRequestHandler<GetCategoryListWithCoursesQuery,
        List<CategoryListWithCoursesDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryListWithCoursesQueryHanlder(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    
    public async Task<List<CategoryListWithCoursesDto>> Handle(GetCategoryListWithCoursesQuery request, CancellationToken cancellationToken)
    {
        var categoriesWithTheirCourses = await _categoryRepository
            .GetCategoriesWithCourses(request.IncludeHistory);

        return _mapper.Map<List<CategoryListWithCoursesDto>>(categoriesWithTheirCourses);
    }
}
