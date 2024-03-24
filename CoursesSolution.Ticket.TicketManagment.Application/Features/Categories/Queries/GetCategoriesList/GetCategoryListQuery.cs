using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListDto>>
    {
    }
}
