using InlämningsUppgiftFullStackApplikation.Models;
using InlämningsUppgiftFullStackApplikation.Services;
using Microsoft.AspNetCore.Mvc;

namespace InlämningsUppgiftFullStackApplikation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(TaskItem task) => Ok(_service.Create(task));

        [HttpPut]
        public IActionResult Update(TaskItem task)
        {
            _service.Update(task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
