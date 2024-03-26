using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence.Repositories;

public class CourseRerpository : BaseRepository<Course> , ICourseRerpository
{
    public CourseRerpository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
    public Task<bool> IsCourseNameAndDateUniq(string name, DateTime date)
    {
        var match = _dbContext.Courses.Any(c => c.Name.Equals(name) && c.Date.Date.Equals(date.Date));
        return Task.FromResult(match);
    }
}
