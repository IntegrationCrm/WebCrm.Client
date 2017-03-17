using System;
using System.Linq.Expressions;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping
{
    public class MappingDefinition<TT>
        where TT : Entity
    {
        public Expression<Func<TT, object>> Property { get; set; }

        public string WebCrmField { get; set; }
    }
}