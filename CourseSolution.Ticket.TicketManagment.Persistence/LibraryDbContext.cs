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

        var cyperSecurityCategoryGuid = Guid.Parse("{4468990c-5382-4a04-b2eb-4ab9275e8d04}");
        var artificialIntelligenceCategoryGuid = Guid.Parse("{14c1fae5-0639-4dd1-9b72-15d522ab394d}");
        var machineLearningCategoryGuid = Guid.Parse("{3c11b904-afc8-4a78-92a9-96eafe236716}");
        var softwareEngineeringCategoryGuid = Guid.Parse("{d4d0f53a-d69f-4a4c-b9a0-3739aaabce0d}");

        // seed the category data
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = cyperSecurityCategoryGuid,
                Name = "Cyber Security"
            },
            new Category
            {
                CategoryId = artificialIntelligenceCategoryGuid,
                Name = "Artificial Intelligence"
            },
            new Category
            {
                CategoryId = machineLearningCategoryGuid,
                Name = "Mechine Learning"
            },
            new Category
            {
                CategoryId = softwareEngineeringCategoryGuid,
                Name = "Software Engineering"
            }
        );

        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{47350736-8037-4e28-aa28-bece19b62d58}"),
            Name = "Introduction to Cyber Security",
            Price = 60.99m,
            CategoryId = cyperSecurityCategoryGuid,
            Author = "Mohammed alzain",
            Date = DateTime.Now.AddMonths(3),
            Description = "you will know if the cyper security is the right indestury for you or not"
        });

        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{c9424aef-44d4-41a6-bfda-987dbe051d87}"),
            Name = "Introduction to Web Development",
            Price = 60.99m,
            CategoryId = softwareEngineeringCategoryGuid,
            Author = "Abdalazim Attya",
            Date = DateTime.Now.AddMonths(3),
            Description = "you will know if the web development is the right indestury for you or not"
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{040313f6-c01e-4f9a-84b9-beb77673973e}"),
            Name = "Advanced Machine Learning",
            Price = 89.99m,
            CategoryId = machineLearningCategoryGuid,
            Author = "Mohanned Rashid",
            Date = DateTime.Now.AddMonths(2),
            Description = "Take your machine learning skills to the next level with this advanced course."
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{77995a0c-3fdb-4b96-8e43-337eb638ea23}"),
            Name = "Mobile App Development",
            Price = 75.50m,
            CategoryId = softwareEngineeringCategoryGuid,
            Author = "Khalid Mohammed",
            Date = DateTime.Now.AddMonths(1),
            Description = "Learn to develop mobile applications for both Android and iOS platforms."
        });
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            CourseId = Guid.Parse("{583951e8-2221-477e-9e07-258fe5096478}"),
            Name = "Artificial Intelligence Fundamentals",
            Price = 65.75m,
            CategoryId = artificialIntelligenceCategoryGuid,
            Author = "Alice Johnson",
            Date = DateTime.Now.AddMonths(4),
            Description = "Discover the basics of artificial intelligence and its applications in various industries."
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{e30ff405-19d0-4288-9321-a63327197f3f}"),
            OrderTotal = 175,
            OrderPaid = false,
            OrderDate = DateTime.Now.AddHours(2),
            UserId = Guid.Parse("{13c35229-9be0-407e-8313-cf142d6b34c2}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{dfa3a946-bc67-4073-8f34-24a36af67088}"),
            OrderTotal = 120,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{de0bdb7f-6dd2-48a4-8f59-553718064d2c}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{7ec834cf-bc6b-453b-835d-520b439afb46}"),
            OrderTotal = 175,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{f6d34e22-f93a-4795-8cb9-76850608e9c4}")
        });

        modelBuilder.Entity<Order>().HasData(new Order()
        {
            OrderId = Guid.Parse("{cf878c8b-0062-4760-9ff3-1e1b50c5ec00}"),
            OrderTotal = 120,
            OrderPaid = false,
            OrderDate = DateTime.Now,
            UserId = Guid.Parse("{1c47de68-219d-4802-9261-46df912438e2}")
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
