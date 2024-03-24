using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand : IRequest
{
    public Guid CourseId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
