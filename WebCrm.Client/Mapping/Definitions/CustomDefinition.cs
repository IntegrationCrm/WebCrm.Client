using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class CustomDefinition<T> : DefinitionBase<T>
        where T : Entity, new()
    {
        public CustomDefinition(
            string id,
            string table,
            DataEntityType dataEntityType,
            string nameclause,
            IEnumerable<MappingDefinition<T>> mappingDefinitions,
            Document.DocumentLinkTypes documentLinkType)
        {
            Id = id;
            Table = table;
            DataEntityType = dataEntityType;
            NameClause = nameclause;
            Definitions = mappingDefinitions;
            DocumentLinkType = documentLinkType;
        }

        public override DataEntityType DataEntityType { get; }

        public override IEnumerable<MappingDefinition<T>> Definitions { get; }

        public override Document.DocumentLinkTypes DocumentLinkType { get; }

        public override string Id { get; }

        public override string NameClause { get; }

        public override string Table { get; }
    }
}