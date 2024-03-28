using CourseSolution.Ticket.TicketManagment.Infrastructure;
using CourseSolution.Ticket.TicketManagment.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseSolution.Ticket.TicketManagment.Api;

public static class StartUpExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSwaggerGen()
            .AddApplicationServices()
            .AddInfrastrutureServices(builder.Configuration)
            .AddPersistenceServices(builder.Configuration)
            .AddControllers(config =>
            {
                config.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                config.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            });

        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
    //reset the database when the application starts for testing Development purposes

    public async static Task ResetDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            if (dbContext != null)
            {
                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database");
        }
    }
}
