using CRUD_Operation_17Apr.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operation_17Apr.Models
{
    public class CustomerModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase customerRequest = controllerContext.HttpContext.Request;
            int CustomerId = Convert.ToInt32(customerRequest.Form.Get("CustomerId"));
            string CustomerName = customerRequest.Form.Get("CustomerName");
            string Address1 = customerRequest.Form.Get("Address1");
            string Address2 = customerRequest.Form.Get("Address2");
            string Phonenumber = customerRequest.Form.Get("Phonenumber");

            return new CustomerAddEditViewModel
            {
                CustomerId = CustomerId,
                CustomerName = CustomerName,
                Address1 = Address1,
                Address2 = Address2,
                Phonenumber = Phonenumber

            };            
        }
    }
}