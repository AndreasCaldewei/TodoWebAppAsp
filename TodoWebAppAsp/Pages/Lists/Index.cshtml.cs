using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoWebAppAsp.Data;
using TodoWebAppAsp.Models;

namespace TodoWebAppAsp.Pages.Lists
{
    public class IndexModel : PageModel
    {
        private readonly TodoWebAppAsp.Data.AppDbContext _context;


        public IndexModel(TodoWebAppAsp.Data.AppDbContext context)
        {
            _context = context;

        }

        public IList<List> List { get;set; }

        public async Task OnGetAsync()
        {
            List = await _context.List.ToListAsync();
        }
    }
}
