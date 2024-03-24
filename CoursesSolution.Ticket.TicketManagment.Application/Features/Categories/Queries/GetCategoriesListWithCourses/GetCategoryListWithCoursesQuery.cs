using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class GetCategoryListWithCoursesQuery 
    : IRequest<List<CategoryListWithCoursesDto>>
{
    public bool IncludeHistory { get; set; }
}
