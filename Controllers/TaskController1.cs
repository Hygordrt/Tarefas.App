using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.App.Data;

namespace Tarefas.App.Controllers
{
    public class TaskController1 : Controller
    {
        private readonly Context _context;

        public TaskController1(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Operação de listagem
            return View(await _context.Tarefas.ToListAsync());
        }

        // Operação para criação de uma nova tarefa
        [HttpGet]
        public IActionResult NovaTarefa()
        {
            return View();
        }

        // Inserir dados no banco
        [HttpPost]
        public async Task<IActionResult> NovaTarefa(Task task)
        {
            // Passando a tarefa criada
            await _context.Tarefas.AddAsync(task);
            // Salvando
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
