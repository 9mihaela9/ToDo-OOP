using System;
using System.Collections.Generic;

class TodoItem
{
    public string Description { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ExpirationDate { get; set; }

    public TodoItem(string description, DateTime expirationDate)
    {
        Description = description;
        CreationTime = DateTime.Now; 
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"Creating date: {CreationTime}, Description: {Description}";
    }
}

class TodoList
{
    private List<TodoItem> items;

    public TodoList()
    {
        items = new List<TodoItem>();
    }

    public void AddTodoItem()
    {
        Console.WriteLine("Enter your todo:");
        string description = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Enter expiration date (YYYY-MM-DD HH:MM): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
            {
                TodoItem newItem = new TodoItem(description, expirationDate);
                items.Add(newItem);
                Console.WriteLine("Todo added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Todo not added.");
            }
        }
    }

    public void RemoveTodoItem()
    {
        Console.WriteLine("Enter the number of the todo to remove:");

        if (!int.TryParse(Console.ReadLine(), out int removeTodoAtIndex))
        {
            Console.WriteLine("Enter valid value");
            return;
        }

        if (removeTodoAtIndex >= 1 && removeTodoAtIndex <= items.Count)
        {
            TodoItem removedTodo = items[removeTodoAtIndex - 1];
            items.RemoveAt(removeTodoAtIndex - 1);
            Console.WriteLine($"Removed todo: {removedTodo}");
        }
        else
        {
            Console.WriteLine("Invalid index. Todo not removed.");
        }
    }

    public void ShowTodos()
    {
        Console.WriteLine("Todo List:");

        int i = 0;
        foreach (TodoItem todo in items)
        {
            Console.WriteLine($"{i + 1}. {todo}");
            i++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TodoList todoList = new TodoList();

        while (true)
        {
            Console.WriteLine("\nType 1 to see todos");
            Console.WriteLine("Type 2 to add todo");
            Console.WriteLine("Type 3 to view the last added Todo");
            Console.WriteLine("Type 4 to remove todo");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Enter a number between 1 and 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    todoList.ShowTodos();
                    break;
                case 2:
                    todoList.AddTodoItem();
                    break;
                case 3:
                    todoList.ShowTodos(); 
                    break;
                case 4:
                    todoList.RemoveTodoItem();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
