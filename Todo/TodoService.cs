using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TodoService
    {
        private readonly TodoRepository _repository = new();
        public List<Todo> GetAllTodo() => _repository.GetAll();
        public Todo AddTodo(string title) => _repository.Add(title);
        public bool UpdateTodo(int id, string title) => _repository.Update(id, title);
        public bool RemoveTodo(int id) => _repository.Delete(id);
        public bool ToggleTodo(int id) => _repository.Toggle(id);
    }
}