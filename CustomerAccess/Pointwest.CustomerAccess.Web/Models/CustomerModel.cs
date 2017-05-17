using Pointwest.CustomerAccess.Logic;
using Pointwest.CustomerAccess.Web.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pointwest.CustomerAccess.Web.Models
{
    public class CustomerModel
    {

        public CustomerModel()
        {
            CustomerList = new List<CustomerViewModel>();

        }

        //Property
        public List<CustomerViewModel> CustomerList { get; set; }


        private CustomerAccessImplementation _customerImplementation = new CustomerAccessImplementation();

        #region Methods

        /// <summary>
        /// Get all customers for table display
        /// </summary>
        public CustomerModel RetrieveAllCustomers()
        {
            CustomerModel responsemodel = new CustomerModel();

            var customers = _customerImplementation.RetrieveAllCustomers();
            responsemodel.CustomerList = CustomerMapper.MapEntitiestoModel(customers);
            return responsemodel;
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        public void AddCustomer(CustomerViewModel model)
        {
            _customerImplementation.AddUpdateCustomer(CustomerMapper.MapModelToEntity(model));
        }

        /// <summary>
        /// Update existing customer
        /// </summary>
        public void UpdateCustomer(CustomerViewModel model)
        {
            _customerImplementation.AddUpdateCustomer(CustomerMapper.MapModelToEntity(model));
        }

        /// <summary>
        /// Retrieve customer by id
        /// </summary>
        public CustomerViewModel GetCustomerByID(int id)
        {
            CustomerViewModel responseModel = CustomerMapper.MapEntityToModel(_customerImplementation.RetrieveCustomerByID(id));
            return responseModel;
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        public void DeleteCustomer(int id)
        {
            _customerImplementation.DeleteCustomer(id);
        }
        #endregion
    }

}