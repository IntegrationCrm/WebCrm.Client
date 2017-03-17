using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCrm.Client.Entities;
using WebCrm.Client.Mapping;
using WebCrm.Client.Utilities;

namespace WebCrm.Client.Repository
{
    public abstract class CustomRepository<TEntity, TWebCrmBaseType> : Repository<TEntity>
        where TEntity : TWebCrmBaseType, IWebCrmUpdatable, IWebCrmQueryable, ILogable, new()
        where TWebCrmBaseType : Entity, new()
    {
        protected CustomRepository()
        {
            BaseMapper = Context.GetMapperForType<TWebCrmBaseType>();
        }

        protected EntityMapper<TWebCrmBaseType> BaseMapper { get; }

        protected override string SelectFields => string.Join(",", Mapper.Fields.Concat(BaseMapper.Fields));

        public override IEnumerable<KeyValuePair> GetLookUp(Expression<Func<TEntity, object>> column)
        {
            string columnName = ReflectionHelpers.GetName(column);

            IEnumerable<KeyValuePair> result = BaseMapper.GetLookUpByColumnName(columnName) ??
                                               Mapper.GetLookUpByColumnName(columnName);

            return result;
        }

        protected override TEntity MapResult(Dictionary<string, string> getDictionary)
        {
            var dto1 = new TEntity();

            BaseMapper.MapTo(getDictionary, dto1);

            Mapper.MapTo(getDictionary, dto1);

            return dto1;
        }

        protected override WebCrmData MapToWebCrmData(TEntity entity)
        {
            KeyValuePair[] basePairs = BaseMapper.GetAllPairs(entity).ToArray();
            KeyValuePair[] pairs = Mapper.GetAllPairs(entity).ToArray();

            var data = new WebCrmData { Pairs = basePairs.Concat(pairs).ToArray() };

            return data;
        }

        protected override WebCrmData MapToWebCrmData(
            TEntity entity,
            IEnumerable<Expression<Func<TEntity, object>>> columns)
        {
            var data = new WebCrmData();

            string[] columnNames = columns.Select(ReflectionHelpers.GetName).ToArray();

            IEnumerable<KeyValuePair> basePairs = columnNames.Select(c => BaseMapper.GetWebCrmPropertyPair(entity, c));
            IEnumerable<KeyValuePair> pairs = columnNames.Select(c => Mapper.GetWebCrmPropertyPair(entity, c));

            data.Pairs = basePairs.Concat(pairs).Where(c => c != null).ToArray();

            return data;
        }
    }
}