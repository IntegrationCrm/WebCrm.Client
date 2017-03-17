using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using WebCrm.Client.Entities;
using WebCrm.Client.Mapping.Definitions;
using WebCrm.Client.Utilities;

namespace WebCrm.Client.Mapping
{
    public sealed class EntityMapper<T> : EntityMapperBase
        where T : Entity, new()
    {
        private readonly DefinitionBase<T> _definition;

        private readonly Dictionary<string, HydratedMapping<T>> _hydratedMappings =
            new Dictionary<string, HydratedMapping<T>>();

        private readonly List<DynamicProperties.Property> _props =
            new List<DynamicProperties.Property>(DynamicProperties.CreatePropertyMethods(typeof(T)));

        internal EntityMapper(
            FieldMetadata[] metaData,
            DefinitionBase<T> definition)
        {
            _definition = definition;
            InitialiseMappings(metaData);
        }

        public DataEntityType DataEntityType => _definition.DataEntityType;

        public Document.DocumentLinkTypes DocumentLinkType => _definition.DocumentLinkType;

        public override IEnumerable<string> Fields
        {
            get { return _hydratedMappings.Select(c => c.Value.CrmFieldName); }
        }

        public string Id => _definition.Id;

        public IEnumerable<MappingDefinition<T>> MappingDefinitions => _definition.Definitions;

        public string NameClause => _definition.NameClause;

        public string Table => _definition.Table;

        public override Type Type => typeof(T);

        public IEnumerable<KeyValuePair> GetAllPairs(object input)
        {
            var pairs = new List<KeyValuePair>();

            _props.ForEach(
                p => { pairs.Add(GetWebCrmPropertyPair(input, p.Info.Name)); });

            return pairs;
        }

        public IEnumerable<KeyValuePair> GetLookUpByColumnName(string columnName)
        {
            MappingDefinition<T> mappingDefinition =
                MappingDefinitions.FirstOrDefault(c => ReflectionHelpers.GetName(c.Property) == columnName);

            if (mappingDefinition == null)
            {
                return null;
            }

            IEnumerable<FieldMetadata> items =
                Context.MetaData.Where(
                    c =>
                        string.Equals(
                            c.DatabaseName,
                            mappingDefinition.WebCrmField,
                            StringComparison.CurrentCultureIgnoreCase));
            FieldMetadata item =
                items.First(
                    c =>
                        string.Equals(
                            c.DatabaseName,
                            mappingDefinition.WebCrmField,
                            StringComparison.CurrentCultureIgnoreCase));

            return item.DropDownItems.Select(c => new KeyValuePair { Key = c.Value, Value = c.Text }).ToList();
        }

        public KeyValuePair GetWebCrmPropertyPair(object input, string columnName)
        {
            if (!_hydratedMappings.ContainsKey(columnName))
            {
                return null;
            }

            DynamicProperties.Property p = _props.First(c => c.Info.Name == columnName);

            HydratedMapping<T> inputKey = _hydratedMappings[p.Info.Name];
            object value = p.Getter.Invoke(input);

            string val = value?.ToString();

            var pair = new KeyValuePair { Key = inputKey.CrmFieldName, Value = val };
            return pair;
        }

        public void MapFrom(object input, IEnumerable<Expression<Func<T, object>>> columns, WebCrmData result)
        {
            var pairs = new List<KeyValuePair>();

            foreach (Expression<Func<T, object>> column in columns)
            {
                string columnName = ReflectionHelpers.GetName(column);

                KeyValuePair pair = GetWebCrmPropertyPair(input, columnName);

                pairs.Add(pair);
            }

            result.Pairs = pairs.Where(c => c != null).ToArray();
        }

        public void MapTo(Dictionary<string, string> input, T result)
        {
            _props.ForEach(
                p =>
                {
                    if (!_hydratedMappings.ContainsKey(p.Info.Name))
                    {
                        return;
                    }

                    HydratedMapping<T> mapping = _hydratedMappings[p.Info.Name];
                    string inputKey = mapping.CrmFieldName;
                    if (!input.ContainsKey(inputKey))
                    {
                        return;
                    }

                    var hydratedMapping = mapping as HydratedLookUpMapping<T>;

                    if (hydratedMapping != null)
                    {
                        DynamicProperties.Property prop =
                            _props.First(c => c.Info.Name == hydratedMapping.DescriptionField);

                        string[] values = input[inputKey].Split(';');
                        var descriptions = new List<string>();

                        foreach (string value in values)
                        {
                            KeyValuePair mappingResult =
                                hydratedMapping.LookupData.FirstOrDefault(c => c.Key == value);
                            if (mappingResult != null)
                            {
                                descriptions.Add(mappingResult.Value);
                            }
                        }

                        prop.Setter.Invoke(result, string.Join(",", descriptions));
                    }

                    if (p.Info.PropertyType == typeof(long))
                    {
                        p.Setter.Invoke(result, long.Parse(input[inputKey]));
                    }
                    else if (p.Info.PropertyType == typeof(decimal))
                    {
                        p.Setter.Invoke(result, decimal.Parse(input[inputKey]));
                    }
                    else if (p.Info.PropertyType == typeof(DateTime))
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        p.Setter.Invoke(result, DateTime.ParseExact(input[inputKey], "dd-MM-yyyy", provider));
                    }
                    else
                    {
                        p.Setter.Invoke(result, input[inputKey]);
                    }
                });
        }

        private static HydratedMapping<T> GetHydratedMapping(MappingDefinition<T> mappingDefinition)
        {
            string descriptionPropertyName = string.Empty;

            var hydratedMapping = new HydratedMapping<T>
            {
                CrmFieldName = mappingDefinition.WebCrmField,
                DescriptionField = descriptionPropertyName
            };
            return hydratedMapping;
        }

        private HydratedMapping<T> GetHydratedLookUpMapping(
            FieldMetadata[] metaData,
            LookUpMappingDefinition<T> lookUpMapping)
        {
            string descriptionPropertyName = ReflectionHelpers.GetName(lookUpMapping.DescriptionProperty);

            IEnumerable<KeyValuePair> lookupData = GetLookUp(lookUpMapping.Property, metaData);

            var hydratedMapping = new HydratedLookUpMapping<T>
            {
                CrmFieldName = lookUpMapping.WebCrmField,
                DescriptionField = descriptionPropertyName,
                LookupData = lookupData
            };
            return hydratedMapping;
        }

        private HydratedMapping<T> GetHydratedMapping(MappingDefinition<T> mappingDefinition, FieldMetadata[] metaData)
        {
            var lookUpMapping = mappingDefinition as LookUpMappingDefinition<T>;
            return lookUpMapping != null
                ? GetHydratedLookUpMapping(metaData, lookUpMapping)
                : GetHydratedMapping(mappingDefinition);
        }

        private IEnumerable<KeyValuePair> GetLookUp(Expression<Func<T, object>> column, FieldMetadata[] metaData)
        {
            string columnName = ReflectionHelpers.GetName(column);

            MappingDefinition<T> mappingDefinition = MappingDefinitions.First(
                c => ReflectionHelpers.GetName(c.Property) == columnName);

            FieldMetadata item =
                metaData.First(
                    c =>
                        string.Equals(
                            c.DatabaseName,
                            mappingDefinition.WebCrmField,
                            StringComparison.CurrentCultureIgnoreCase));

            return item.DropDownItems.Select(c => new KeyValuePair { Key = c.Value, Value = c.Text }).ToList();
        }

        private void InitialiseMappings(FieldMetadata[] metaData)
        {
            foreach (MappingDefinition<T> mapping in MappingDefinitions)
            {
                string propertyName = ReflectionHelpers.GetName(mapping.Property);

                HydratedMapping<T> hydratedMapping = GetHydratedMapping(mapping, metaData);

                _hydratedMappings.Add(propertyName, hydratedMapping);
            }
        }
    }
}