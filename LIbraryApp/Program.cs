using LIbraryApp.Controller;
using Service.Helpers.Enums;

var authorController = GetAuthorController();
var bookController = GetBookController();

while (true)
{
    ShowMenus();
    Console.WriteLine("Choose one operation:");

Operation:
    string? operationStr = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(operationStr))
    {
        Console.WriteLine("Input can't be empty");
        goto Operation;
    }

    bool operationCorrectFormat = int.TryParse(operationStr, out int operation);
    if (!operationCorrectFormat)
    {
        Console.WriteLine("Input format is wrong");
        goto Operation;
    }

    Console.Clear();

    switch ((Operations)operation)
    {
        // Author Operations
        case Operations.CreateAuthor:
            await authorController.ExecuteCreate();
            break;
        case Operations.GetAllAuthors:
            await authorController.ExecuteGetAll();
            break;
        case Operations.GetAuthorById:
            await authorController.ExecuteGetById();
            break;
        case Operations.DeleteAuthor:
            await authorController.ExecuteDelete();
            break;

        // Book Operations
        case Operations.CreateBook:
            await bookController.ExecuteCreate();
            break;
        case Operations.GetAllBooks:
            await bookController.ExecuteGetAll();
            break;
        case Operations.GetBookById:
            await bookController.ExecuteGetById();
            break;
        case Operations.DeleteBook:
            await bookController.ExecuteDelete();
            break;

        case Operations.Exit:
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Operation not found");
            goto Operation;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

AuthorController GetAuthorController()
{
    return new AuthorController();
}

BookController GetBookController()
{
    return new BookController();
}

void ShowMenus()
{
    Console.WriteLine("========== LIBRARY APP ==========\n");

    Console.WriteLine("AUTHOR OPERATIONS:");
    Console.WriteLine("1 - Create Author");
    Console.WriteLine("2 - Get All Authors");
    Console.WriteLine("3 - Get Author by Id");
    Console.WriteLine("4 - Delete Author\n");

    Console.WriteLine("BOOK OPERATIONS:");
    Console.WriteLine("5 - Create Book");
    Console.WriteLine("6 - Get All Books");
    Console.WriteLine("7 - Get Book by Id");
    Console.WriteLine("8 - Delete Book\n");

    Console.WriteLine("0 - Exit");
    Console.WriteLine("================================");
}