using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        public void ShowTodos()
        {
            Console.WriteLine("====DANH SÁCH CÔNG VIỆC====");
            foreach (var item in _service.GetAllTodo())
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("1. Thêm mới công việc");
            Console.WriteLine("2. Đánh dấu công việc");
            Console.WriteLine("3. Sửa công việc");
            Console.WriteLine("4. Xoá công việc");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
        }
        public void Add()
        {
            Console.Write("Nhập nội dung công việc: ");
            string input = Console.ReadLine();
            _service.AddTodo(input);
        }
        public void Delete()
        {
            Console.Write("Nhập Id muốn xoá: ");
            int id = int.Parse(Console.ReadLine());
            _service.RemoveTodo(id);
        }
        public void Toggle()
        {
            Console.Write("Nhập Id muốn đánh dấu: ");
            int id = int.Parse(Console.ReadLine());
            _service.ToggleTodo(id);
        }
        public void Update()
        {
            Console.Write("Nhập Id muốn sửa: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhập nội dung mới: ");
            string title = Console.ReadLine();
            _service.UpdateTodo(id, title);
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowTodos();
                ShowMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Add(); break;
                    case "2":
                        Toggle(); break;
                    case "3":
                        Update(); break;
                    case "4":
                        Delete(); break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
            Console.WriteLine("Nhấn nút bất kỳ để tiếp tục");
            Console.ReadLine();
        }
    }
}