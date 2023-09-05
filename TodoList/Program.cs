
using TodoList;

//AddTodoClass addTodoClass = new AddTodoClass();

TodoClass todoClass = new TodoClass();

bool exitRequest = false;
List<string> todos = new List<string>();


while (!exitRequest)
{
    try
    {
        todoClass.Todos();
        string input = Console.ReadLine();

        int i;
        switch (input.ToUpper())
        {
            case "S":
                SeeTodos();
                break;
            case "A":
                AddTodo();
                //or like this >> addTodoClass.AddTodo(todos);
                break;
            case "R":
                RemoveTodo();
                break;
            case "E":
                exitRequest = true;
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    catch (InvalidDataException ex)
    {
        Console.WriteLine("error, invalid input" + ex.Message);
    }

}

void SeeTodos()
{
    if (todos.Count == 0)
    {

        ShowNoTodoMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine("Add todo:");
        description = Console.ReadLine();
    } while (!isDescriptionValid(description));

    todos.Add(description);
}

bool isDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("Can not be empty");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine("You already have that");
        return false;
    }
    else
    {
        return true;
    }
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    bool removeBool = false;
    while (!removeBool)
    {
        Console.WriteLine("Select index of todos you want to remove.");
        SeeTodos();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Can not be empty");
            continue;
        }
        if (int.TryParse(userInput, out int index) && index <= todos.Count && index > 0)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            removeBool = true;
            Console.WriteLine($"Todo: {todoToBeRemoved} at index: {index} removed");
            
        }
        else
        {
            Console.WriteLine("Not good");
        }

    }
}

static void ShowNoTodoMessage()
{
    Console.WriteLine("No todos have been added.");
}