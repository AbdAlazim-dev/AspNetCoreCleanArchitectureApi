using CoursesSolution.Ticket.TicketManagment.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.Contracts.Infrastruture;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
