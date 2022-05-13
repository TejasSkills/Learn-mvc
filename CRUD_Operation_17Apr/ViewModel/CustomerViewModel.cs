using CRUD_Operation_17Apr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operation_17Apr.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phonenumber { get; set; }
        public List<CustomerViewModel> ToCustomerViewModel(List<Customer> obj)
        {
            return obj.Select(customer => new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                Phonenumber = customer.Phonenumber
            }).ToList();            

        }
    }
}