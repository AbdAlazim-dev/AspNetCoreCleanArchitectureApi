using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.UnitTest.Mocks;

public class RepositoryMocks
{
    public static Mock<IAsyncRerository<Category>> GetCategoryRepository()
    {
        var cyperSecurityCategoryGuid = Guid.Parse("{4468990c-5382-4a04-b2eb-4ab9275e8d04}");
        var artificialIntelligenceCategoryGuid = Guid.Parse("{14c1fae5-0639-4dd1-9b72-15d522ab394d}");
        var machineLearningCategoryGuid = Guid.Parse("{3c11b904-afc8-4a78-92a9-96eafe236716}");
        var softwareEngineeringCategoryGuid = Guid.Parse("{d4d0f53a-d69f-4a4c-b9a0-3739aaabce0d}");

        var categories = new List<Category>();
        // seed the category data
        categories.AddRange(new List<Category>
        {
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
        });

        var mockRepository = new  Mock<IAsyncRerository<Category>>();
        mockRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

        mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
            (Category category) =>
            {
                categories.Add(category);
                return category;
            });
        return mockRepository;
    }
}
