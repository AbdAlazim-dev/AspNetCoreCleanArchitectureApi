using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Commands;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Dtos;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesListWithCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseSolution.Ticket.TicketManagment.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllCategories")]
        public async Task<ActionResult<List<CategoryListDto>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }
        [HttpGet("courses", Name = "GetAllCategoriesWithCourses")]
        public async Task<ActionResult<List<CategoryListWithCoursesDto>>> GetAllCategoriesWithCourses()
        {
            var categoriesWithCourses =
                await _mediator.Send(new GetCategoryListWithCoursesQuery()
                { IncludeHistory = false });
            return Ok(categoriesWithCourses);
        }
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryDto>> Create(
            [FromBody] CreateCategoryCommand createCategoryDto)
        {
            var response = await _mediator.Send(createCategoryDto);
            return Ok(response);
        }
    }
}
