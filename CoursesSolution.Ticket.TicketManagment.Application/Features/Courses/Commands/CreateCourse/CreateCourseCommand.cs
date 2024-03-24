using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public override string ToString()
    {
        return $"Course Name: {Name};" +
            $" By the Author: {Author};" +
            $" Price: {Price};" +
            $" on: {Date.ToShortDateString()};" +
            $" Description: {Description};";
    }
}
