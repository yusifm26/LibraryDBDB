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
    internal class AuthorController
    {
        private readonly IAuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }

        public async Task ExecuteCreate()
        {
        NameInput:
            Console.WriteLine("Enter author fullname:");
            string fullname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Fullname can't be empty!");
                goto NameInput;
            }

            if (!fullname.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Console.WriteLine("Input format is incorrect");
                goto NameInput;
            }

        AgeInput:
            Console.WriteLine("Enter author age:");
            string ageInput = Console.ReadLine();

            if (!int.TryParse(ageInput, out int age) || age <= 0)
            {
                Console.WriteLine("Invalid age format!");
                goto AgeInput;
            }

            await _authorService.CreateAsync(new Author
            {
                FullName = fullname,
                Age = age
            });

            Console.WriteLine("Author created successfully");
        }

        public async Task ExecuteGetAll()
        {
            var authors = await _authorService.GetAllAsync();

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Id} {author.FullName} {author.Age}");
            }
        }

        public async Task ExecuteGetById()
        {
        IdInput:
            Console.WriteLine("Enter author ID:");
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

            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                Console.WriteLine("ID not found");
                return;
            }

            Console.WriteLine($"{author.Id} {author.FullName} {author.Age}");
        }

        public async Task ExecuteDelete()
        {
            await ExecuteGetAll();

        IdInput:
            Console.WriteLine("Enter author ID to delete:");
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

            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
            {
                Console.WriteLine("ID not found");
                goto IdInput;
            }

            await _authorService.DeleteAsync(id);
            Console.WriteLine("Author deleted successfully");
        }
    }
}
