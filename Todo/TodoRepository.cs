using System;
using System.Collections.Generic;
using System.Text;

namespace Todo
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = new();
        private int _nextID;
        private readonly string _filePath = "todos.txt";

        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsSuccess { get; private set; }

        public TodoRepository()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_filePath)) return;
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var item = Todo.FromFileString(line);
                _todos.Add(item);
                if (item.Id >= _nextID)
                    _nextID = item.Id + 1;
            }
        }
        public void SaveChanges()
        {
            File.WriteAllLines(_filePath, _todos.Select(x => x.ToString()));
        }
        public List<Todo> GetAll() => _todos;
        public Todo Add(string title)
        {
            var todo = new Todo()
            {
                Id = _nextID++,
                Title = title,
                IsSuccess = false
            };
            _todos.Add(todo);
            SaveChanges();
            return todo;
        }
        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(int id, string title)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                todo.Title = Title;
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool Toggle(int id)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            if (todo != null)
            {
                todo.IsSuccess = !todo.IsSuccess;
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}