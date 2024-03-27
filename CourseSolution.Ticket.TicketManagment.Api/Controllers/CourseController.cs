using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.DeleteCourse;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Commands.UpdateCourse;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Dtos;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Queries.GetAllCourses;
using CoursesSolution.Ticket.TicketManagment.Application.Features.Courses.Queries.GetCourseDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseSolution.Ticket.TicketManagment.Api.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllCourses")]
        public async Task<ActionResult<List<CourseDto>>> GetAllCourses()
        {
            var courseDtos = await _mediator.Send(new GetCoursesListQuery());
            return Ok(courseDtos);
        }
        [HttpGet("{id}", Name = "GetCourseById")]
        public async Task<ActionResult<CourseDto>> GetCourseById(Guid id)
        {
            var courseDto = await _mediator.Send(new GetCourseDetailQuery() { Id = id });
            return Ok(courseDto);
        }
        [HttpPut(Name = "UpdateCourse")]
        public async Task<ActionResult<CourseDto>> UpdateCourse([FromBody] UpdateCourseCommand updateCourseCommand)
        {
            await _mediator.Send(updateCourseCommand);
            return NoContent();
        }
        [HttpDelete(Name = "DeleteCourse")]
        public async Task<ActionResult<CourseDto>> DeleteCourse(Guid courseId)
        {
            await _mediator.Send(new DeleteCourseCommand() { CourseId = courseId});
            return NoContent();
        }
    }
}
