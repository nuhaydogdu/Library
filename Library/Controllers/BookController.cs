using Library.Context;
using Library.Dto;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        //öncelikle database imizi çekme işlemini yapıyoruz 
        MyDbContext _db;                     
        IBookRepository _repoBook;
        IAuthorRepository _repoAuthor;  
        public BookController(MyDbContext db, IBookRepository repoBook, IAuthorRepository repoAuthor)
        {
            _db = db;
            _repoBook= repoBook;
            _repoAuthor= repoAuthor;    

        }

        //x den kastımız kitap => x.Author da ilişkilendirdiğimiz tablo (bir tabloya iki farklı tabloyu include ettik -> ->)
        //eğer bir tablodan bir tabloya ondan da başka bir tabloya include edersek ThenInclude kullanıyoruz
        public IActionResult BookList()
        {
            List<Book> books= _repoBook.GetBooks(); 

            return View(books);
        }




        //öncelikle yeni bir kitap oluşturmak için ihtiyacımız olan şeyler neler bunu için book medele bakıyoruz
        //book create edebilmek için yazarlar ve kitap türlerini almamız gerekiyor
        //select methodu ile sadece dilediğimiz kolonları listeliyoruz
        //Auther db'sinden çekdiğimiz değerlerde kullanmadığımmız alanlar var -created,uptadet ve statuslar (bu bilgiler boş olarak dahi gitmesin diye dto(data transfer object veri ajtarım nesnesi oluşturuyoruz.
        public IActionResult Create()
        {
            List<AuthorDto> authors= _repoAuthor.SelectAuthorDto();

                    List<BookTypeDto> bookTypes= _db.BookTypes.Where(x=> x.Status != Enums.DataStatus.Deleted).Select(x => 
            new BookTypeDto()
                {
                ID = x.ID,
                Name =x.Name,         
                }).ToList();

            return View((new Book(),authors,bookTypes));
        }





        //view den controllere bir veri gelecek form üzerinden bunu alabilmek için tuple nesnemizin içerisinde üç tane nesne var bunlardan birini almak istiyoruz view deki verilerin hepsi book a yapışıyor o yüzden bizde book üzerinden işlemlerimizi yaptık 
        //kullanımı aşağıdaki gibi -[Bind(Prefix="Item1")] Book book
        [HttpPost]
        public IActionResult Create([Bind(Prefix="Item1")] Book book)
        {
            _repoBook.Add(book);    
            return RedirectToAction("BookList");
        }
    }
}
