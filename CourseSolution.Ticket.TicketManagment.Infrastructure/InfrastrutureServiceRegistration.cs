using CourseSolution.Ticket.TicketManagment.Infrastructure.Mail;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Infrastruture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Infrastructure;

public static class InfrastrutureServiceRegistration
{
    public static IServiceCollection RegisterInfrastrutureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}
