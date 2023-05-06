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
            return View(await _context.Tarefas.ToListAsync());
        }
    }
}
