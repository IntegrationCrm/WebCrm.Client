using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal abstract class DefinitionBase<T>
        where T : Entity
    {
        public abstract DataEntityType DataEntityType { get; }

        public abstract IEnumerable<MappingDefinition<T>> Definitions { get; }

        public abstract Document.DocumentLinkTypes DocumentLinkType { get; }

        public abstract string Id { get; }

        public abstract string NameClause { get; }

        public abstract string Table { get; }
    }
}