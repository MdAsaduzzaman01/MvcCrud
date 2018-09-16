using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}