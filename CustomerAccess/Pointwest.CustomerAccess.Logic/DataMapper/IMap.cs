using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointwest.CustomerAccess.Logic.DataMapper
{
    public interface IDtoModelMap
    {
        object MapModel(object source);
        object MapDto(object source);
        IEnumerable MapModels(IEnumerable entities);
        IEnumerable MapDtos(IEnumerable entities);
    }

    public interface IMap<ModelType, DtoType> : IDtoModelMap
    {
        DtoType Map(ModelType source);
        ModelType Map(DtoType source);
        IList<DtoType> Map(IEnumerable<ModelType> entities);
    }
}
