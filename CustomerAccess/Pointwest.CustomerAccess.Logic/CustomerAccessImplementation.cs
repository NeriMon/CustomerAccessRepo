using Pointwest.CustomerAccess.Data;
using Pointwest.CustomerAccess.DTO;
using Pointwest.CustomerAccess.Logic.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pointwest.CustomerAccess.Logic
{
    public class CustomerAccessImplementation
    {
        CustomerAccessRepository<Customer> repository = new CustomerAccessRepository<Customer>();

        public CustomerDTO RetrieveCustomerByID(int id)
        {

            CustomerDTO customerDTO = new CustomerDTO();

            Customer customer = repository.RetrieveById(id);

            if (customer != null)
            {
                customerDTO = CustomerMapper.GetInstance().Map(customer, customerDTO);
            }
            return customerDTO;
        }

        public List<CustomerDTO> RetrieveAllCustomers()
        {
            List<CustomerDTO> customerDTOList = new List<CustomerDTO>();

            List<Customer> customerList = repository.RetrieveAll();

            if (customerList != null)
            {
                foreach (Customer cs in customerList)
                {
                    CustomerDTO customerDTO = new CustomerDTO();
                    customerDTO = CustomerMapper.GetInstance().Map(cs, customerDTO);
                    customerDTOList.Add(customerDTO);
                }
            }

            return customerDTOList;

        }

        public void DeleteCustomer(int id)
        {
            Customer customerToDelete = repository.RetrieveById(id);

            if(customerToDelete != null)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    repository.Delete(customerToDelete);
                    ts.Complete();
                }
            }
        }

        public void AddUpdateCustomer(CustomerDTO cs)
        {
            Customer customerToAdd = new Customer();
            if (cs != null)
            {
                customerToAdd = CustomerMapper.GetInstance().Map(cs, customerToAdd);

                //Add New Customer
                if (customerToAdd.CustomerID == 0)
                {
                    customerToAdd.CreatedBy = "Admin"; //Use user context
                    customerToAdd.CreatedDate = DateTime.Now;

                    using (TransactionScope ts = new TransactionScope())
                    {
                        repository.Insert(customerToAdd);
                        ts.Complete();
                    }
                }
                //Update Existing Customer
                else
                {
                    //Retrieve existing customer
                    Customer existingCs = repository.RetrieveById(customerToAdd.CustomerID);
                    using (TransactionScope ts = new TransactionScope())
                    {
                        repository.Update(UpdateExistingCustomerData(customerToAdd, existingCs));
                        ts.Complete();
                    }
                }

            }
        }

        //Update the data that needs updating
        private Customer UpdateExistingCustomerData(Customer updated, Customer existing)
        {
            if (updated != null)
            {
                existing.LastName = updated.LastName;
                existing.FirstName = updated.FirstName;
                existing.BirthDate = updated.BirthDate;
                existing.ModifiedBy = "Admin"; //use user context
                existing.ModifiedDate = DateTime.Now;
            }
            return existing;
        }
    }
}
