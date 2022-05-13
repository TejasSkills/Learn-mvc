using CRUD_Operation_17Apr.Models;
using CRUD_Operation_17Apr.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operation_17Apr.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            
            List<Customer> CustomerList = dbContext.Customers.ToList();
            CustomerViewModel CustomerModelList = new CustomerViewModel();
            var list = CustomerModelList.ToCustomerViewModel(CustomerList);
            return View("CustomerView", list);
        }

        public ActionResult Create()
        {
            return View(new CustomerAddEditViewModel());
        }

        [HttpPost]
        public ActionResult AddUpdateData([ModelBinder(typeof(CustomerModelBinder))]CustomerAddEditViewModel customerDetail)
        {
            if (ModelState.IsValid)
            {
                if (customerDetail.CustomerId > 0)
                {
                    //var customerInsertDetails = customerDetail.ToCustomerAddEditModel(customerDetail);
                    //dbContext.Entry(customerInsertDetails).State = EntityState.Modified;                   

                    var customer = dbContext.Customers.Find(customerDetail.CustomerId);
                    customerDetail.ToCustomerAddEditModel(customerDetail, customer);
                }
                else
                {
                    var customerInsertDetails = customerDetail.ToCustomerAddEditModel(customerDetail);
                    dbContext.Customers.Add(customerInsertDetails);
                }

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            if(customerDetail.CustomerId > 0)
            {
                return View(nameof(EditCustomer), customerDetail);
            }
            return View(nameof(Create), customerDetail);
        }

        public ActionResult EditCustomer(int customerId)
        {
            CustomerAddEditViewModel customerObject = new CustomerAddEditViewModel();
            Customer objCust = dbContext.Customers.Find(customerId);
            var editview = customerObject.ToCustomerAddEditViewModel(objCust);
            return View("Create", editview);
        }

        public ActionResult DeleteCustomer(int customerId)
        {            
            Customer objCust = dbContext.Customers.Find(customerId);
            dbContext.Customers.Remove(objCust);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}