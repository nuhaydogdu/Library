using Library.Dto;
using Library.Models;
using System.Collections.Generic;

namespace Library.RepositoryPattern.Interfaces
{
    //burada methodumuzun imzasını hazırlamış oluyoruz 
    public interface IAuthorRepository: IRepository<Author>
    {
        List<AuthorDto> SelectAuthorDto();
    }
}
