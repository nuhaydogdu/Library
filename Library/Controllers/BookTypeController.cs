using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    public class BookTypeController : Controller
    {
        IRepository<BookType> _repoBookType;

        //IOC mekanizmasından bu veriyi dependency injection yaparak çekeceğiz -IRepository<BookType> repoBookType
        //bu işlemlerin sonucunda artık elimizde ilgili modelle(T) ile bir repository var. 
        public BookTypeController(IRepository<BookType> repoBookType)
        {
            _repoBookType = repoBookType;
        }

        public IActionResult BookTypeList()
        {
            List<BookType> bookTypes = _repoBookType.GetAll();
            return View(bookTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookType bookType)
        {
            _repoBookType.Add(bookType);    
            return RedirectToAction("BookTypeList");
        }

        public IActionResult Edit(int id)
        {
            BookType bookType = _repoBookType.GetById(id);
            return View(bookType);
        }
        [HttpPost]
        public IActionResult Edit(BookType bookType)
        {
            _repoBookType.Update(bookType);
            return RedirectToAction("BookTypeList");
        }

        public IActionResult HardDelete(int id)
        {
           _repoBookType.specialDelete(id);
            return RedirectToAction("BookTypeList");
        }
    }
}
