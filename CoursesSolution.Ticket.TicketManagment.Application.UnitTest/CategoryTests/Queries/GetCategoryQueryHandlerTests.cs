using AutoMapper;
using CoursesSolution.Ticket.TicketManagment.Application.Contracts.Persistence;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
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

namespace CoursesSolution.Ticket.TicketManagment.Application.UnitTest.CategoryTests.Queries;

public class GetCategoryQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRerository<Category>> _mockCategoryRepository;
    public GetCategoryQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
                {
            cfg.AddProfile<CategoryProfile>();
        });
        _mapper = configurationProvider.CreateMapper();
    }
    [Fact]
    public async Task GetCategoryListTest()
    {
        // Arrange
        var handler = new GetCategoryListQueryHandler(_mockCategoryRepository.Object, _mapper);

        // Act
        var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);
        
        // Assert
        result.ShouldBeOfType<List<CategoryListDto>>();

        // check the count of the result
        result.Count.ShouldBe(4);
    }
}
