using Library.Context;
using Library.Dto;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.RepositoryPattern.Concrete
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MyDbContext db):base(db)
        {

        }

        public List<AuthorDto> SelectAuthorDto()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).Select(x =>
            new AuthorDto()
            { 
                FirstName = x.FirstName,
                LastName = x.LastName,
                ID = x.ID,
            }).ToList();

        }
    }
}
