using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetCoursesListQuery : IRequest<List<CourseDto>>
    {
    }
}
