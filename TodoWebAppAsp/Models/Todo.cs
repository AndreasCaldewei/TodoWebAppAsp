using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAppAsp.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }

    }
}
