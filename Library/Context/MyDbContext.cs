using Library.Enums;
using System;
using static Library.Context.MyDbContext;
using System.Collections.Generic;
using System.Reflection.Emit;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Configurations;

namespace Library.Context
{

        public class MyDbContext: DbContext
        {

        //bağlantı adresini constructor üzerinden alma işlemi (*)
        //Veri tabanı bağlantısı için MyDbContext içerisine bir constructor oluşturduk ve dependency injection üzerinden DbContextOptions'ı(DbContextOptions<MyDbContext> options) aldık.  
        //Base keywordu: Miras alınan sınıfın constructoruna bir parametre göndermek için kullanılıyor.(yani biz burada miras aldıpımız üst sınıf olan DbContext constructoruna bir options göndermiş olduk)
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {
            
            }


    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            //Konfigrasyonları hangi sınıdıf için yapacaksak onun burada bir instancesini üretiyoruz -new OperationConfiguration()
            modelBuilder.ApplyConfiguration(new OperationConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
                                                            
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            }



            public DbSet<Student> Students { get; set; }

            public DbSet<Book> Books { get; set; }
            public DbSet<BookType> BookTypes { get; set; }

            public DbSet<Operation> Operations { get; set; }
            public DbSet<Author> Authors { get; set; }
        }

}
