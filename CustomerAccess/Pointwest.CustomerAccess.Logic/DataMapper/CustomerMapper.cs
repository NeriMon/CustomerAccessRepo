using Pointwest.CustomerAccess.Data;
using Pointwest.CustomerAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwest.CustomerAccess.Logic.DataMapper
{
    public class CustomerMapper : Mapper<Customer, CustomerDTO, CustomerMapper>
    {
        /// <summary>
        /// Map database entities to DTO
        /// </summary>
        public override CustomerDTO Map(Customer domainEntity, CustomerDTO dtoEntity)
        {
            if (domainEntity == null)
            {
                return null;
            }
            if (dtoEntity == null)
            {
                dtoEntity = new CustomerDTO();
            }
            dtoEntity.ID = domainEntity.CustomerID;
            dtoEntity.LastName = domainEntity.LastName;
            dtoEntity.FirstName = domainEntity.FirstName;
            dtoEntity.BirthDate = domainEntity.BirthDate;
            dtoEntity.CreatedBy = domainEntity.CreatedBy;
            dtoEntity.CreatedDate = domainEntity.CreatedDate;
            dtoEntity.ModifiedBy = domainEntity.ModifiedBy;
            dtoEntity.ModifiedDate = domainEntity.ModifiedDate;
            return dtoEntity;
        }

        /// <summary>
        /// Map DTO to database entities
        /// </summary>
        public override Customer Map(CustomerDTO dtoEntity, Customer domainEntity)
        {
            if (dtoEntity == null)
            {
                return null;
            }
            if (domainEntity == null)
            {
                domainEntity = new Customer();
            }
            domainEntity.CustomerID = dtoEntity.ID;
            domainEntity.LastName = dtoEntity.LastName;
            domainEntity.FirstName = dtoEntity.FirstName;
            domainEntity.BirthDate = dtoEntity.BirthDate;
            domainEntity.CreatedBy = dtoEntity.CreatedBy;
            domainEntity.CreatedDate = dtoEntity.CreatedDate;
            domainEntity.ModifiedBy = dtoEntity.ModifiedBy;
            domainEntity.ModifiedDate = dtoEntity.ModifiedDate;
            return domainEntity;
        }
    }
}
