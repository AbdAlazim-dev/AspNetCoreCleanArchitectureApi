using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;

public class CategoryCourseDto
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
}
