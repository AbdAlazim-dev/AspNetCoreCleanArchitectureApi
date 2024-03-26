using CourseSolution.Ticket.TicketManagment.Persistence.Repositories;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(builder =>
        {
            //the connection string will come from the api project when we register the services
            builder.UseSqlServer(configuration.GetConnectionString("LibraryConnectionString"));
        });

        //register the base repository Implementation and spicific repository Implementation
        services.AddScoped(typeof(IAsyncRerository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository, CategoryRerpository>();
        services.AddScoped<ICourseRerpository, CourseRerpository>();

        return services;
    }
}
