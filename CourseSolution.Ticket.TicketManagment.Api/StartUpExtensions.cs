using CourseSolution.Ticket.TicketManagment.Infrastructure;
using CourseSolution.Ticket.TicketManagment.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application;
using Microsoft.EntityFrameworkCore;

namespace CourseSolution.Ticket.TicketManagment.Api;

public static class StartUpExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplicationServices()
            .AddInfrastrutureServices(builder.Configuration)
            .AddPersistenceServices(builder.Configuration)
            .AddControllers();

        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();
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
