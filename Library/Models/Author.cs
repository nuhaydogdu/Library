using System.Collections.Generic;

namespace Library.Models
{
    public class Author: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //relational property

        public List<Book> Books { get; set; }

    }
}
