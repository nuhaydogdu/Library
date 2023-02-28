using Library.Enums;
using System;

namespace Library.Models
{
    public class BaseEntity
    {
        //Tüm sısnıflar BaseEntityden miras alıyor(Tüm sısnıflarda bulunan ortak alanları içeriyor.
        // BaseEntity ilgili sınıftan çalıştırıldığında CreatedDate, Status değerleri direkt olarak atanıyor
        public BaseEntity()
        {
           CreatedDate = DateTime.Now;
           Status=DataStatus.Inserted;
        }


        public int ID { get; set; }
        public DataStatus Status { get; set; }     //Enums klasörü içerisinde bulunan public enum DataStatus'u kullanıyoruz
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
