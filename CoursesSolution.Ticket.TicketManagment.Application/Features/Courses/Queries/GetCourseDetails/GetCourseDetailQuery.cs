using CoursesSolution.Ticket.TicketManagment.Application.Features.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Features.Courses
{
    public class GetCourseDetailQuery : IRequest<CourseDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
