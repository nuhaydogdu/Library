using Library.Context;
using Library.Models;
using Library.RepositoryPattern.Base;
using Library.RepositoryPattern.Concrete;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Startup
    {
        //appsetting.json i�erisindeki i�erisindeki bir dosyay� kullanbilmmek i�in IConfiguration interfacesini kullanmak gerekiyor

        //art�k ilgili T ile elimizde bir repository var 
        readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            object value = services.AddDbContext<MyDbContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:MsSql"] ?? ""));
            services.AddControllersWithViews();

            //repository methodlar�n� BookTypeController i�erisinde kullanmak i�in ilk olarak yeni bir servis olu�turmak gerekiyor(IOC k�t�phanesine yeni bir nesne tan�taca��z)
            //ilk �nce interface bununda bir modele(T) ihtiyac� var, ikinci olarak nesneyi(Repository) yaz�yoruz ayn� �ekilde buna da bir model vermemiz gerekiyor
            //�nce interface sonra class� ekliyoruz 
            services.AddScoped < IRepository<BookType>, Repository<BookType>>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
