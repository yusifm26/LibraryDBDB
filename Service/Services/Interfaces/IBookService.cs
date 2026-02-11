using Domain.Entities;


namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(Book book);
        Task DeleteAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> SearchByName(string searchText);
    }
}
