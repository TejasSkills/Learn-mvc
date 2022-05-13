using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operation_17Apr.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phonenumber { get; set; }
    }
}