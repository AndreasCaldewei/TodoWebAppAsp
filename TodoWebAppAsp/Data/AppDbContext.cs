using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoWebAppAsp.Models;

namespace TodoWebAppAsp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoWebAppAsp.Models.List> List { get; set; }

        public DbSet<TodoWebAppAsp.Models.Todo> Todo { get; set; }
    }
}
