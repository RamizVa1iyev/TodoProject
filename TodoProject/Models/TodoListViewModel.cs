using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProject.Models.Entitiy;

namespace TodoProject.Models
{
    public class TodoListViewModel
    {
        public List<Todo> Todos { get; set; }
        public Todo Todo { get; set; }
        public string Key { get; set; }
    }
}
