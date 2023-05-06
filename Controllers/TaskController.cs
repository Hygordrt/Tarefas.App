using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarefas.App.Data;

namespace Tarefas.App.Controllers
{
    public class TaskController : Controller
    {
        private readonly Context _context;

        public TaskController(Context context)
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
        public async Task<IActionResult> NovaTarefa(TaskModel tarefa)
        {
            // Passando a tarefa criada
            await _context.Tarefas.AddAsync(tarefa);
            // Salvando
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Atualizar os dados
        [HttpGet]
        public async Task<IActionResult> EditarTarefa(int Id)
        {
            // Buscando a tarefa em Tarefas passando o Id
            TaskModel tarefa = await _context.Tarefas.FindAsync(Id);

            return View(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarefa(TaskModel tarefa)
        {
            _context.Tarefas.Update(tarefa);
            // Refletir no banco de dados
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Excluir tarefa
        [HttpPost]
        public async Task<IActionResult> DeletarTarefa(int Id)
        {
            // Buscando a tarefa em Tarefas passando o Id
            TaskModel tarefa = await _context.Tarefas.FindAsync(Id);
            
            _context.Tarefas.Remove(tarefa);
            // Salvando a ação remover 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
