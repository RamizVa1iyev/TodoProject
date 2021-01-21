using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoProject.Models.Entitiy
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
