using Domain.Entities;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbraryApp.Controller
{
    internal class BookController
    {
        private readonly IBookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }

        public async Task ExecuteCreate()
        {
        NameInput:
            Console.WriteLine("Enter book name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can't be empty!");
                goto NameInput;
            }

            if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Console.WriteLine("Input format is incorrect");
                goto NameInput;
            }

            await _bookService.CreateAsync(new Book
            {
                Name = name
            });

            Console.WriteLine("Book created successfully");
        }

        public async Task ExecuteGetAll()
        {
            var books = await _bookService.GetAllAsync();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id} {book.Name}");
            }
        }

        public async Task ExecuteGetById()
        {
        IdInput:
            Console.WriteLine("Enter book ID:");
            string idInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idInput))
            {
                Console.WriteLine("ID can't be empty!");
                goto IdInput;
            }

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID format!");
                goto IdInput;
            }

            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                Console.WriteLine("ID not found");
                return;
            }

            Console.WriteLine($"{book.Id} {book.Name}");
        }

        public async Task ExecuteDelete()
        {
            await ExecuteGetAll();

        IdInput:
            Console.WriteLine("Enter book ID to delete:");
            string idInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idInput))
            {
                Console.WriteLine("ID can't be empty!");
                goto IdInput;
            }

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid ID format!");
                goto IdInput;
            }

            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                Console.WriteLine("ID not found");
                goto IdInput;
            }

            await _bookService.DeleteAsync(id);
            Console.WriteLine("Book deleted successfully");
        }
    }
}
