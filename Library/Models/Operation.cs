using System;

namespace Library.Models
{
    //book ve student arasındaki çoka çok ilişkiyi ifade edebilmek için Operation sonofono oluşturduk
    public class Operation: BaseEntity
    {
        public int StudentID { get; set; }
        public int BookID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //rational property

        public Student Student{ get; set; }
        public Book Book { get; set; }

    }
}
