using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System.Linq.Expressions;


namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }
        public async Task CreateAsync(Book book)
        {
            await _bookRepository.CreateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
                await _bookRepository.DeleteAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchByName(string searchText)
        {
           return  await _bookRepository.SearchByCondition(m=>m.Name.Contains(searchText));
        }
    }
}
