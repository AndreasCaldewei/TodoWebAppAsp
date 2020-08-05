using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoWebAppAsp.Data;
using TodoWebAppAsp.Models;

namespace TodoWebAppAsp.Pages.Todos
{
    public class EditModel : PageModel
    {
        private readonly TodoWebAppAsp.Data.AppDbContext _context;

        public EditModel(TodoWebAppAsp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Todo Todo { get; set; }
        public List<List> TodoLists { get; private set; }

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

            this.TodoLists = await this._context.List.ToListAsync();


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(Todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoExists(Guid id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
