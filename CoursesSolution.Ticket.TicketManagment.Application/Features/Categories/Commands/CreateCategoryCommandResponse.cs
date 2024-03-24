using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using CoursesSolution.Ticket.TicketManagment.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {
    }

    public CreateCategoryDto Category { get; set; } = default!;
}
