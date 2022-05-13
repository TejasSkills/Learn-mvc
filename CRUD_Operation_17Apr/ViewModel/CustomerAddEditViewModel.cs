using CRUD_Operation_17Apr.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Operation_17Apr.ViewModel
{
    public class CustomerAddEditViewModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [ValidPhoneNumber(ErrorMessage ="Phone number must start with +91")]
        public string Phonenumber { get; set; }


        public Customer ToCustomerAddEditModel(CustomerAddEditViewModel customerDetail)
        {
            Customer cust = new Customer();
            cust.CustomerId = customerDetail.CustomerId;
            cust.CustomerName = customerDetail.CustomerName;
            cust.Address1 = customerDetail.Address1;
            cust.Address2 = customerDetail.Address2;
            cust.Phonenumber = customerDetail.Phonenumber;

            return cust;
        }

        public void ToCustomerAddEditModel(CustomerAddEditViewModel customerDetail, Customer cust)
        {
            cust.CustomerName = customerDetail.CustomerName;
            cust.Address1 = customerDetail.Address1;
            cust.Address2 = customerDetail.Address2;
            cust.Phonenumber = customerDetail.Phonenumber;

        }

        public CustomerAddEditViewModel ToCustomerAddEditViewModel(Customer customerDetail)
        {
            CustomerAddEditViewModel obj = new CustomerAddEditViewModel();
            obj.CustomerId = customerDetail.CustomerId;
            obj.CustomerName = customerDetail.CustomerName;
            obj.Address1 = customerDetail.Address1;
            obj.Address2 = customerDetail.Address2;
            obj.Phonenumber = customerDetail.Phonenumber;

            return obj;
        }
    }

    public class ValidPhoneNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (Convert.ToString(value).StartsWith("+91"))
                return true;

            return false;
        }
    }
}