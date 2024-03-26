using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRerpository
{
    public OrderRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
