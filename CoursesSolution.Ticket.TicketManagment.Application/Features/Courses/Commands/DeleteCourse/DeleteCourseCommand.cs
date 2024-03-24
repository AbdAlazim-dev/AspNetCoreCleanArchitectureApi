using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.DeleteCourse;

//when deleting a course, you can only know if its delted or not throw the save changes method
public class DeleteCourseCommand : IRequest
{
    public Guid CourseId { get; set; }
}
