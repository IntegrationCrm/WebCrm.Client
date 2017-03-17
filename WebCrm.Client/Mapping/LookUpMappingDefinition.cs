using System;
using System.Linq.Expressions;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping
{
    internal class LookUpMappingDefinition<TT> : MappingDefinition<TT>
        where TT : Entity
    {
        public Expression<Func<TT, object>> DescriptionProperty { get; set; }
    }
}