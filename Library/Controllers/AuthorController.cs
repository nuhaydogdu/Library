using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        MyDbContext _db;
        IAuthorRepository _repoAuthor;

        public AuthorController(MyDbContext db, IAuthorRepository repoAuthor)
        {
            _db = db;
            _repoAuthor = repoAuthor;   
        }
    
        public IActionResult AuthorList()
        {
            List<Author> authors = _repoAuthor.GetActive();

           // List<Author> authors = _db.Authors.Where(a => a.Status != Enums.DataStatus.Deleted).ToList();
           //DataStatus değeri deleted(2) olarak işaretlenmemiş olanları listeliyor sadece
           //Aşağıdaki delete methodunda tamamen silmiyoruz sadece statusunu değiştirdik buradada sadece aktif olanları sıralamasını istedik ()soft delete deniyor
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repoAuthor.Add(author);
            return RedirectToAction("AuthorList");  //farklı bir actiona burada yönlendirme yapıyoruz 
        }

        public IActionResult Edit(int id)
        {
            Author author = _repoAuthor.GetById(id);         //GetById(id) //Author author = _db.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _repoAuthor.Update(author); 
            return RedirectToAction("AuthorList");
        }

        public IActionResult Delete(int id)
        {
           _repoAuthor?.Delete(id);
            return RedirectToAction("AuthorList");
        }
    }
}
