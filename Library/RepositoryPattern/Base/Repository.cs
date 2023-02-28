using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Library.RepositoryPattern.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        MyDbContext _db;
        protected DbSet<T> table;  
        //Repositoryden miras alan sınıflarda table yi kullanabilsin diye protected yaptık  (default olrak private) 
        public Repository(MyDbContext db)
        {
            //banan gelecek ola T modelini tablo olarak tutumuş oldum(add veya update işlemlerinde bu tableyi kullancağım)
            table=db.Set<T>();
            _db = db;
        }

        private void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
           table.Add(item);
            Save();
        }

        //bir tabloda aradığım kriterlerle bir kayıt var mı varsa true yoksa false
        public bool Any(Expression<Func<T, bool>> exp)     
        {
            return table.Any(exp);
        }

        public int Count()
        {
           return table.Count();  
        }

        public void Delete(int id)
        {
           T item=table.Find(id);   
            item.Status=Enums.DataStatus.Deleted;
            item.ModifiedDate=DateTime.Now;
            table.Update(item);
            Save();
        }

        public List<T> GetActive()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).ToList();  
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);  
        }

        public List<T> SelectActivesByLimit(int count)
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).ToList().Take(count).ToList();
        }

        public void specialDelete(int id)
        {
             T item = GetById(id);
            table.Remove(item);
            Save();
        }

        public void Update(T item)
        {
            item.Status = Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }
    }
}
