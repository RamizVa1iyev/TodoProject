using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TodoProject.Extensions;
using TodoProject.Helpers.Abstract;
using TodoProject.Models.Entitiy;

namespace TodoProject.Helpers.Concrete
{
    public class TodoSessionHelper:ITodoSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public TodoSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public List<Todo> GetTodoList(string key)
        {
            var todos = _httpContextAccessor.HttpContext.Session.GetObject<List<Todo>>(key);
            if (todos==null)
            {
                SetTodoList(key,new List<Todo>());
                todos = _httpContextAccessor.HttpContext.Session.GetObject<List<Todo>>(key);
            }

            return todos;
        }

        public void SetTodoList(string key, List<Todo> todos)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key,todos);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
