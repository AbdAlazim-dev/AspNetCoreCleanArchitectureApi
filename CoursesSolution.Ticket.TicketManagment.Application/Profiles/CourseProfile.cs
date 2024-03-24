using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.CreateCourse;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.UpdateCourse;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CourseDetailsDto, Course>().ReverseMap();

            //for commands
            CreateMap<Course, CreateCourseCommand>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();
        }
    }
}
