using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;

public class CategoryListWithCoursesDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CourseDto>? Courses { get; set; }
}
