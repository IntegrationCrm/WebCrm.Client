using System;
using System.Collections.Generic;

namespace WebCrm.Client.Mapping
{
    public abstract class EntityMapperBase
    {
        public abstract IEnumerable<string> Fields { get; }

        public abstract Type Type { get; }
    }
}