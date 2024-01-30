using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Models.Dto.Book;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface IBookRepository: IBaseRepository<Book>
    {
         Task<List<Book>> GetBook(BookDto BookDto);

        Task<List<Book>> GetBookWithElk(List<int> BookIds);

        Task<Book> GetBookDetail(string url, int languageId);
        Task<bool> CheckCode(string searchText);

    }
}