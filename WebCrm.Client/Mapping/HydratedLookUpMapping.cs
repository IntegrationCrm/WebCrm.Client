using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping
{
    internal sealed class HydratedLookUpMapping<TT> : HydratedMapping<TT>
        where TT : Entity
    {
        public IEnumerable<KeyValuePair> LookupData { get; set; }
    }
}