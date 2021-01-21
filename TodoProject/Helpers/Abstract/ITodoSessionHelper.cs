using System.Collections.Generic;
using TodoProject.Models.Entitiy;

namespace TodoProject.Helpers.Abstract
{
    public interface ITodoSessionHelper
    {
        List<Todo> GetTodoList(string key);
        void SetTodoList(string key, List<Todo> todos);
        void Clear();
    }
}
