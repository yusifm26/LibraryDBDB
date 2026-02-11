using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum Operations
    {
        CreateAuthor = 1,
        GetAllAuthors = 2,
        GetAuthorById = 3,
        DeleteAuthor = 4,
        CreateBook = 5,
        GetAllBooks = 6,
        GetBookById = 7,
        DeleteBook = 8,
        Exit = 0
    }
}
