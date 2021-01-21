using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProject.Models.Entitiy;

namespace TodoProject.Helpers.Abstract
{
    public interface ITodoHelper
    {
        int Length { get; }
        string SessionKey { get; }
        List<Todo> GetTodos();
        List<Todo> GetTodosByTitle(string key);
        bool AddTodoToSession(Todo todo);
        void DeleteTodoToSession(int id);
        void ClearTodos();
    }
}
