using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;
using CoursesSolution.Ticket.TicketManagment.Application.Profiles;
using CoursesSolution.Ticket.TicketManagment.Application.UnitTest.Mocks;
using CoursesSolution.Ticket.TicketManagment.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSolution.Ticket.TicketManagment.Application.UnitTest.CategoryTests.Commands;

public class CreateCategoryCommandTest
{
    private readonly Mock<IAsyncRerository<Category>> _mockCategoryRepository;
    private readonly IMapper _mapper;
    public CreateCategoryCommandTest()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CategoryProfile>();
        });
        _mapper = configurationProvider.CreateMapper();
    }
    [Fact]
    public async Task AddCategoryCommandTest()
    {
        //Arrange
        var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);
        await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

        //Act
        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

        //Assert
        allCategories.Count.ShouldBe(5);

    }
}
