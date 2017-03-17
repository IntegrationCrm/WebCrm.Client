using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebCrm.Client.Entities;
using WebCrm.Client.Mapping;

namespace WebCrm.Client
{
    public class CustomMappingBuilder<TCustomType, TBaseType, TEnum>
        where TCustomType : TBaseType, new()
        where TBaseType : Entity, new()
    {
        private readonly IList<MappingDefinition<TCustomType>> _definitions = new List<MappingDefinition<TCustomType>>();

        internal CustomMappingBuilder()
        {
        }

        public CustomMappingBuilder<TCustomType, TBaseType, TEnum> AddLookUpMapping(
            Expression<Func<TCustomType, object>> mappingProperty,
            TEnum mappingWebCrmField,
            Expression<Func<TCustomType, object>> descriptionProperty)
        {
            string mappingField = mappingWebCrmField.ToString();

            WithCustomLookUpMapping(mappingProperty, mappingField, descriptionProperty);

            return this;
        }

        public CustomMappingBuilder<TCustomType, TBaseType, TEnum> AddMapping(
            Expression<Func<TCustomType, object>> mappingProperty,
            TEnum mappingWebCrmField)
        {
            string mappingField = mappingWebCrmField.ToString();

            WithCustomMapping(mappingProperty, mappingField);

            return this;
        }

        public void Build()
        {
            Context.AddCustomDefinition<TCustomType, TBaseType>(_definitions);
        }

        internal void WithCustomLookUpMapping(
            Expression<Func<TCustomType, object>> mappingProperty,
            string mappingWebCrmField,
            Expression<Func<TCustomType, object>> descriptionProperty)
        {
            var mapping = new LookUpMappingDefinition<TCustomType>
            {
                WebCrmField = mappingWebCrmField,
                Property = mappingProperty,
                DescriptionProperty = descriptionProperty
            };

            _definitions.Add(mapping);
        }

        internal void WithCustomMapping(
            Expression<Func<TCustomType, object>> mappingProperty,
            string mappingWebCrmField)
        {
            var mapping = new MappingDefinition<TCustomType>
            {
                WebCrmField = mappingWebCrmField,
                Property = mappingProperty
            };

            _definitions.Add(mapping);
        }
    }
}