using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProject.Helpers.Abstract;
using TodoProject.Models;
using TodoProject.Models.Entitiy;

namespace TodoProject.Controllers
{
    public class TodoController : Controller
    {
        private ITodoHelper _todoHelper;

        public TodoController(ITodoHelper todoHelper)
        {
            _todoHelper = todoHelper;
        }

        public IActionResult List(string key)
        {
            var model = new TodoListViewModel()
            {
                Todos =_todoHelper.GetTodosByTitle(key)
            };
            return View(model);
        }

        public IActionResult AddTodo(Todo todo)
        {
            todo.Id = _todoHelper.Length+1;
            todo.AddedTime=DateTime.Now;
            _todoHelper.AddTodoToSession(todo);
            return RedirectToAction("List");
        }

        public IActionResult DeleteTodo(int id)
        {
            _todoHelper.DeleteTodoToSession(id);
            TempData.Add("message", "Todo Deleted!");
            TempData.Add("className", "success");
            return RedirectToAction("List");
        }

        public IActionResult Clear()
        {
            _todoHelper.ClearTodos();
            return RedirectToAction("List");
        }
    }
}
