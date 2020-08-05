using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoWebAppAsp.Data;
using TodoWebAppAsp.Models;

namespace TodoWebAppAsp.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly TodoWebAppAsp.Data.AppDbContext _context;

        public DetailsModel(TodoWebAppAsp.Data.AppDbContext context)
        {
            _context = context;
        }

        public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);

            if (Todo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
