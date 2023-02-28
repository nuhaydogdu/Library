using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Library.RepositoryPattern.Interfaces
{
    //bütün modeller bu interfaceden faydalanabilecekler (Generic<T> yapıda bir inreface olacak)
    //where T : BaseEntity => T BaseEntity veya base entityden misras almış herşeydir
    //Burada veri tabanı üzerinde yapacağımız sorguların methodlarının imzalarını barındıracağız(interface)
    public interface IRepository<T> where T : BaseEntity
    {
       
       

        List<T> GetAll();
        List<T> GetActive();

        T GetById(int id);        //Author author = _db.Authors.Find(id); 

        void Add(T item);               
        void Update(T item);     

        void Delete(int id);
        void specialDelete(int id);
        List<T> GetByFilter(Expression<Func<T, bool>> exp);        //Where(a => a.Status != Enums.DataStatus.Deleted)
        int Count();

        bool Any(Expression<Func<T, bool>> exp);

        List<T> SelectActivesByLimit(int count);

    }
}
