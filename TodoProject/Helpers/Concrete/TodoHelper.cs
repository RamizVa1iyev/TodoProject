using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TodoProject.Helpers.Abstract;
using TodoProject.Models.Entitiy;

namespace TodoProject.Helpers.Concrete
{
    public class TodoHelper:ITodoHelper
    {
        private ITodoSessionHelper _todoSessionHelper;
        private IHttpContextAccessor _httpContextAccessor;
        private ITempDataDictionaryFactory _tempDataDictionaryFactory;
        public TodoHelper(ITodoSessionHelper todoSessionHelper, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _todoSessionHelper = todoSessionHelper;
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }

        public string SessionKey => "todos";

        public int Length => GetTodos().Count;

        public List<Todo> GetTodos()
        {
            return _todoSessionHelper.GetTodoList(SessionKey);
        }

        public List<Todo> GetTodosByTitle(string key)
        {
            if (key==null)
            {
                return GetTodos();
            }
            else
            {
                return GetTodos().Where(t => t.Title.ToLower().Contains(key.ToLower())).ToList();
            }
        }

        public bool AddTodoToSession(Todo todo)
        {
            var todos = _todoSessionHelper.GetTodoList(SessionKey);
            var httpContext = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(httpContext);
            if (string.IsNullOrEmpty(todo.Title))
            {
                tempData.Add("message","Please write a todo");
                tempData.Add("className", "danger");
                return false;
            }
            else if (todos.Any(t => string.Equals(t.Title.Replace(" ",""), todo.Title.Replace(" ", ""), StringComparison.CurrentCultureIgnoreCase)))
            {
                tempData.Add("message","Please write different todo");
                tempData.Add("className", "danger");
                return false;
            }
            else
            {
                todos.Add(todo);
                _todoSessionHelper.SetTodoList(SessionKey, todos);
                return true;
            }
        }

        public void DeleteTodoToSession(int id)
        {
            var todos = _todoSessionHelper.GetTodoList(SessionKey);
            var todo = todos.FirstOrDefault(t => t.Id == id);
            todos.Remove(todo);
            _todoSessionHelper.SetTodoList(SessionKey,todos);
        }

        public void ClearTodos()
        {
            _todoSessionHelper.Clear();
        }
    }
}
