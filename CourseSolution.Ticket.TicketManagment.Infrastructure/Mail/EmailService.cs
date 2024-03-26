using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Infrastruture;
using CoursesSolution.Ticket.TicketManagment.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public EmailSettings _mailSettings { get; }
    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;   
    }
    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_mailSettings.ApiKey);

        var to = new EmailAddress(email.To);
        var subject = email.Subject;
        var emailBody = email.Body;

        var from = new EmailAddress
        {
            Email = _mailSettings.FromAddress,
            Name = _mailSettings.FromName
        };

        var sendGridMessage = MailHelper
            .CreateSingleEmail(from, to, subject, emailBody, emailBody);
        var response = await client.SendEmailAsync(sendGridMessage);

        if(response.StatusCode == System.Net.HttpStatusCode.Accepted ||
            response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return true;
        }

        return false;
    }
}
