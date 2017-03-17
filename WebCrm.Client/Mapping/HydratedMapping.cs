using System;
using System.Linq.Expressions;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping
{
    internal class HydratedMapping<TT>
        where TT : Entity
    {
        public string CrmFieldName { get; set; }

        public string DescriptionField { get; set; }

        public Expression<Func<TT, object>> DescriptionProperty { get; set; }
    }
}