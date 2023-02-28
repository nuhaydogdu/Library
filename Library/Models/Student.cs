using Library.Enums;
using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class Student: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        //ratioanal property

        public List<Operation> Operations { get; set; }

        public virtual StudentDetail StudentDetail { get; set; }

    }
}
