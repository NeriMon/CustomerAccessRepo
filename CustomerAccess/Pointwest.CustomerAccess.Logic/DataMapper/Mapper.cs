using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwest.CustomerAccess.Logic.DataMapper
{
    public abstract class Mapper<DomainType, DtoType, MapImplType> : IMap<DomainType, DtoType>
        where MapImplType : class, new()
    {
        private static MapImplType instance = new MapImplType();

        /// <returns>
        /// An <see cref="IList{T}"/> of conversion-generated <see cref="DtoType"/> objects,
        /// or null if a null <see cref="ICollection{T}"/> or domain entities was provided.
        /// </returns>
        public IList<DtoType> Map(ICollection<DomainType> domainEntities)
        {
            if (domainEntities == null)
            {
                return null;
            }

            IList<DtoType> dtoEntities = new List<DtoType>();

            foreach (DomainType domainEntity in domainEntities)
            {
                DtoType dtoEntity = Map(domainEntity);
                dtoEntities.Add(dtoEntity);
            }

            return dtoEntities;
        }

        public IList<DomainType> Map(ICollection<DtoType> dtoEntities)
        {
            if (dtoEntities == null)
            {
                return null;
            }

            IList<DomainType> domainEntities = new List<DomainType>();

            foreach (DtoType dtoEntity in dtoEntities)
            {
                DomainType domainEntity = Map(dtoEntity);
                domainEntities.Add(domainEntity);
            }

            return domainEntities;
        }

        public DtoType Map(DomainType domainEntity)
        {
            DtoType dtoEntity = Map(domainEntity, default(DtoType));

            return dtoEntity;
        }

        public DomainType Map(DtoType dtoEntity)
        {
            DomainType domainEntity = Map(dtoEntity, default(DomainType));

            return domainEntity;
        }

        public IList<DtoType> Map(IEnumerable<DomainType> entities)
        {
            throw new NotImplementedException();
        }

        public static MapImplType GetInstance()
        {
            return instance;
        }

        public static MapImplType Instance
        {
            get { return instance; }
        }


        public abstract DtoType Map(DomainType domainEntity, DtoType dtoEntity);

        public abstract DomainType Map(DtoType dtoEntity, DomainType domainEntity);

        #region Implementation of IDtoModelMap

        public object MapModel(object source)
        {
            return this.Map((DomainType)source);
        }

        public object MapDto(object source)
        {
            return this.Map((DtoType)source);
        }

        public IEnumerable MapModels(IEnumerable entities)
        {
            var result = this.Map((ICollection<DomainType>)entities);
            return result;
        }

        public IEnumerable MapDtos(IEnumerable entities)
        {
            var result = this.Map((ICollection<DtoType>)entities);
            return result;
        }

        #endregion
    }
}
