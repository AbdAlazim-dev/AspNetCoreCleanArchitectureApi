using CoursesSolution.Ticket.TicketManagment.Domain.Common;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSolution.Ticket.TicketManagment.Persistence;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        //apply the configuration in all assemply
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

        var cyperSecurityCategoryGuid = Guid.Parse("{B5A3D7A4-3D3A-4D3B-8D0A-5D3A3D3A3D3A}");
        var artificialIntelligenceCategoryGuid = Guid.Parse("{B5A3D7A4-3D3A-4D3B-8D0A-5D3A3D3A3D3B}");
        var mechineLearningcategoryGuid = Guid.Parse("{B5A3D7A4-3D3A-4D3B-8D0A-5D3A3D3A3D3C}");
        var softwareEngineeringCategoryGuid = Guid.Parse("{B5A3D7A4-3D3A-4D3B-8D0A-5D3A3D3A3D3D}");

        // seed the category data
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = cyperSecurityCategoryGuid,
                Name = "Cyber Security"
            },
            new Category
            {
                Id = artificialIntelligenceCategoryGuid,
                Name = "Artificial Intelligence"
            },
            new Category
            {
                Id = mechineLearningcategoryGuid,
                Name = "Mechine Learning"
            },
            new Category
            {
                Id = softwareEngineeringCategoryGuid,
                Name = "Software Engineering"
            }
        );

        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{a139d77f-c482-4398-8844-6c253edefdc7}"),
            Name = "Introduction to Cyber Security",
            Price = 60.99m,
            CategoryId = cyperSecurityCategoryGuid,
            Author = "Mohammed alzain",
            Date = DateTime.Now.AddMonths(3),
            Description = "you will know if the cyper security is the right indestury for you or not"
        });

        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{c462d9e6-1895-413b-b919-5ed9291f7b9f}"),
            Name = "Introduction to Web Development",
            Price = 60.99m,
            CategoryId = softwareEngineeringCategoryGuid,
            Author = "Abdalazim Attya",
            Date = DateTime.Now.AddMonths(3),
            Description = "you will know if the web development is the right indestury for you or not"
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{7c16490b-a16f-4453-86d1-a4411ad1acc4}"),
            Name = "Advanced Machine Learning",
            Price = 89.99m,
            CategoryId = mechineLearningcategoryGuid,
            Author = "Mohanned Rashid",
            Date = DateTime.Now.AddMonths(2),
            Description = "Take your machine learning skills to the next level with this advanced course."
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{d0d68073-83d0-4755-8831-01ea1a03e4b8}"),
            Name = "Mobile App Development",
            Price = 75.50m,
            CategoryId = softwareEngineeringCategoryGuid,
            Author = "Khalid Mohammed",
            Date = DateTime.Now.AddMonths(1),
            Description = "Learn to develop mobile applications for both Android and iOS platforms."
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{d41db62d-d57d-4783-83bc-1042b048ef03}"),
            Name = "Artificial Intelligence Fundamentals",
            Price = 65.75m,
            CategoryId = artificialIntelligenceCategoryGuid,
            Author = "Alice Johnson",
            Date = DateTime.Now.AddMonths(4),
            Description = "Discover the basics of artificial intelligence and its applications in various industries."
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{7fd5e071-3fbd-4b98-a0b2-41f75fa3bec1}"),
            OrderTotal = 175,
            OrderPaid = false,
            OrderDate = DateTime.Now.AddHours(2),
            UserId = Guid.Parse("{7fd5e071-3fbd-4b98-a0b2-41f75fa3bsc2}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{7fd5e071-3fdd-4b98-c0b2-41f75fa3bec1}"),
            OrderTotal = 120,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{7fs5e071-3fsd-4b98-a0b2-41f75fa3bsc2}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{2fd5e071-2fbd-4b98-a0b2-41f75fa3bec1}"),
            OrderTotal = 175,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{1cd5e071-3fbd-4b98-a0b2-41f75fa3bsc2}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{7fd5e071-3fdd-6f98-c0b2-41f75fa3bec1}"),
            OrderTotal = 120,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{1fs5e071-3fsd-4b98-a0b2-11f15fa3bsc2}")
        });

        
    }

    // override the SaveChangesAsync method to update the CreatedAt and LastModified properties
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken 
        = new CancellationToken())
    {
        // every entity that implements the IAuditableEntity will have the CreatedAt and LastModified properties
        // updated when the entity is added or modified
        foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.LastModified = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
