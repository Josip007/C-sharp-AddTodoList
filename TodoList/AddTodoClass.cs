using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class AddTodoClass
    {
        public void AddTodo(List<string> addTodoList) 
        {                      
                bool descriptionBool = true;
                while (descriptionBool)
                {
                    Console.WriteLine("Add todo:");
                    var description = Console.ReadLine();
                    if (description == "")
                    {
                        Console.WriteLine("Can not be empty");
                    }
                    else if (addTodoList.Contains(description))
                    {
                        Console.WriteLine("You already have that");
                    }
                    else
                    {
                        addTodoList.Add(description);
                        Console.WriteLine("Added successfully");
                        descriptionBool = false;
                    }
                }
        }
    }
}
