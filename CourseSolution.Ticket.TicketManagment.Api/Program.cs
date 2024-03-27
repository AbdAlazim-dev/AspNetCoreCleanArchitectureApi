using CourseSolution.Ticket.TicketManagment.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices();

await app
    .ConfigurePipeline()
    .ResetDatabase();

app.Run();
