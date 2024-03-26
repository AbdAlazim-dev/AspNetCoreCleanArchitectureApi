using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence.Repositories;

public class CategoryRerpository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRerpository(LibraryDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<List<Category>> GetCategoriesWithCourses(bool includeHistory)
    {
        var allCategories = await _dbContext.Categories.Include(c => c.Courses).ToListAsync();
        if (!includeHistory)
        {
            allCategories.ForEach(c => c.Courses.ToList().RemoveAll(c => c.Date > DateTime.Today));
        }

        return allCategories;
    }

    public async Task<bool> IsCategoryNameUnique(string name)
    {
        bool isItUniqName = await _dbContext.Categories.AnyAsync(c => c.Name == name);
        return await Task.FromResult(isItUniqName);
    }
}
