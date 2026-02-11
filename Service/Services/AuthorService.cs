using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }

        public async Task CreateAsync(Author author)
        {
            await _authorRepository.CreateAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author != null)
                await _authorRepository.DeleteAsync(author);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }
    }
}
