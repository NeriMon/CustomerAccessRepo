using Pointwest.CustomerAccess.DTO;
using Pointwest.CustomerAccess.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pointwest.CustomerAccess.Web.Mapper
{
    public class CustomerMapper 
    {
        public static CustomerViewModel MapEntityToModel(CustomerDTO entity)
        {
            CustomerViewModel model = new CustomerViewModel();

            if (entity != null)
            {
                model.ID = entity.ID;
                model.LastName = entity.LastName;
                model.FirstName = entity.FirstName;
                model.BirthDate = entity.BirthDate;
            }
            return model;
        }

        public static CustomerDTO MapModelToEntity(CustomerViewModel model)
        {
            CustomerDTO entity = new CustomerDTO();

            if (model != null)
            {
                entity.ID = model.ID;
                entity.LastName = model.LastName;
                entity.FirstName = model.FirstName;
                entity.BirthDate = model.BirthDate;
            }
            return entity;
        }

        public static List<CustomerViewModel> MapEntitiestoModel(List<CustomerDTO> entities)
        {
            List<CustomerViewModel> modelList = new List<CustomerViewModel>();
            if (entities != null)
            {
                foreach (CustomerDTO cs in entities)
                {
                    CustomerViewModel customer = new CustomerViewModel();
                    customer.ID = cs.ID;
                    customer.LastName = cs.LastName;
                    customer.FirstName = cs.FirstName;
                    customer.BirthDate = cs.BirthDate;
                    modelList.Add(customer);
                }
            }
            return modelList;
        }
    }
}