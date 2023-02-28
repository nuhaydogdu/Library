using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.RepositoryPattern.Concrete
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MyDbContext db) : base(db)
        {
        }

        public List<Book> GetBooks()
        {
            return table.Where(b => b.Status != Enums.DataStatus.Deleted).Include(x => x.Author)
                .Include(x => x.BookType).ToList();
        }
    }
}
