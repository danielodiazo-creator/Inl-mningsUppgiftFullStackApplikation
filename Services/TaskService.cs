using InlämningsUppgiftFullStackApplikation.Data;
using InlämningsUppgiftFullStackApplikation.Models;

namespace InlämningsUppgiftFullStackApplikation.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAll() => _context.Tasks.ToList();

        public TaskItem GetById(int id) =>
            _context.Tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void Update(TaskItem updatedTask)
        {
            _context.Tasks.Update(updatedTask);
            _context.SaveChanges();
        }



    }
}
