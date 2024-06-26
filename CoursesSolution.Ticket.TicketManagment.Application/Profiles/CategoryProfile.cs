﻿using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryCourseDto>();
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<Category, CategoryListWithCoursesDto>().ReverseMap();

        //Commands 
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreateCategoryCommandResponse>().ReverseMap();
    }
}
