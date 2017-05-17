using Pointwest.CustomerAccess.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pointwest.CustomerAccess.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get all customers for table display
        /// </summary
        public JsonResult RetrieveAllCustomers()
        {
            CustomerModel model = new CustomerModel();

            model = model.RetrieveAllCustomers();

            return Json(model.CustomerList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Add new customer
        /// </summary>
        public string AddCustomer(CustomerViewModel customer)
        {
            CustomerModel model = new CustomerModel();
            if (customer != null)
            {
                model.AddCustomer(customer);
                return "Customer added successfully";
            }
            else
            {
                return "Invalid customer record";
            }
        }

        /// <summary>
        /// Update existing customer
        /// </summary>
        public string UpdateCustomer(CustomerViewModel customer)
        {
            CustomerModel model = new CustomerModel();
            if (customer != null)
            {
                model.UpdateCustomer(customer);
                return "Customer updated successfully";
            }
            else
            {
                return "Invalid customer record";
            }
        }

        /// <summary>
        /// Get customer details by id
        /// </summary>
        public JsonResult GetCustomerByID(string id)
        {
            CustomerModel model = new CustomerModel();
            CustomerViewModel responseModel = new CustomerViewModel();

            if (!String.IsNullOrWhiteSpace(id))
            {
                responseModel = model.GetCustomerByID(Convert.ToInt32(id));
            }
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Delete customer by id
        /// </summary>
        public string DeleteCustomer(string id)
        {
            CustomerModel model = new CustomerModel();
            if (!String.IsNullOrWhiteSpace(id))
            {
                model.DeleteCustomer(Convert.ToInt32(id));
                return "Selected customer deleted sucessfully";
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}