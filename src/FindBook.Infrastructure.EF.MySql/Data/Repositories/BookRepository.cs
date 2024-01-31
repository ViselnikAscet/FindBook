using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Enum;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class ProductRepository : BaseRepository<Book>, IBookRepository
    {

        public ProductRepository(FindBookContext context, ILogger<ProductRepository> logger) : base(context, logger)
        {

        }

        public Task<bool> CheckCode(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBook(BookDto BookDto)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookDetail(string url, int languageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetBookWithElk(List<int> BookIds)
        {
            throw new NotImplementedException();
        }






        // 



    }
}