using InlämningsUppgiftFullStackApplikation.Models;
using InlämningsUppgiftFullStackApplikation.Services;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetById(int id)
        {
            var task = _service.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            var createdTask = _service.Create(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var existingTask = _service.GetById(id);
            if (existingTask == null) return NotFound();

            // Actualizamos solo los campos que queremos
            existingTask.Title = updatedTask.Title;
            existingTask.IsDone = updatedTask.IsDone;

            _service.Update(existingTask);
            return NoContent(); // 204 es estándar para PUT exitoso sin devolver objeto
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}