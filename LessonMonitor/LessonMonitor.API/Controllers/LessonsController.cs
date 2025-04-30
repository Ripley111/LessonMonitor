using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        public LessonsController() { }

        [HttpGet("lessons", Name = "GetLessons")]
        public IEnumerable<Lesson> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new Lesson
            {
                Name = $"Lesson number {index}",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }
    }
}
