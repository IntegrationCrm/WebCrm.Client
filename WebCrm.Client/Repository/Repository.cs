using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCrm.Client.Entities;
using WebCrm.Client.Mapping;
using WebCrm.Client.Utilities;

namespace WebCrm.Client.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IWebCrmUpdatable, IWebCrmQueryable, ILogable, new()
    {
        private readonly IConnection _connection;
        private readonly string _idClause = "({0} = {1})";

        public Repository()
        {
            _connection = Context.CreateConnection();
            Mapper = Context.GetMapperForType<TEntity>();
        }

        protected virtual int Colspan => 5;

        protected EntityMapper<TEntity> Mapper { get; }

        protected virtual string SelectFields => string.Join(",", Mapper.Fields);

        protected string TableName => Mapper.Table;

        public long Add(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> columns)
        {
            WebCrmData data = MapToWebCrmData(entity, columns);

            WriteToWebCrmResult retval = _connection.Proxy.WriteToWebcrmDirect(
                _connection.Ticket,
                Mapper.DataEntityType,
                entity.OrganisationId,
                0,
                data);

            if (retval.ErrorStatus.Code != 0)
            {
                throw new ApplicationException($"Error occurred adding {retval.ErrorStatus.Message}");
            }

            return retval.ID;
        }

        public long AddDocument(
            byte[] file,
            long organisationId,
            string description,
            string fileExtension,
            string fileName,
            string folder,
            long id)
        {
            var documentData = new WebCrmDocumentData
            {
                OrganisationId = organisationId,
                Description = description,
                FileExtension = fileExtension,
                FileName = fileName,
                Folder = folder,
                LinkedEntityId = id,
                LinkedEntityType = (int)Mapper.DocumentLinkType
            };

            SaveDocumentDataResult retval = _connection.Proxy.SaveDocument(_connection.Ticket, documentData, file);

            if (retval.ErrorStatus.Code != 0)
            {
                throw new ApplicationException($"Error occurred updating {retval.ErrorStatus.Message}");
            }

            return retval.ID;
        }

        public TEntity GetById(long id)
        {
            string where = string.Format(_idClause, Mapper.Id, id);
            return QueryAllFields(where).First();
        }

        public TEntity GetByName(string name)
        {
            string where = string.Format(Mapper.NameClause, name);
            return QueryAllFields(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return QueryAllFields(string.Empty);
        }

        public virtual IEnumerable<KeyValuePair> GetLookUp(Expression<Func<TEntity, object>> column)
        {
            string columnName = ReflectionHelpers.GetName(column);

            return Mapper.GetLookUpByColumnName(columnName);
        }

        public void Log(long id, long organisationId, string log)
        {
            string logFormat = "/A/<tr><td colspan=\"" + Colspan + "\" class=\"smallc\">{0}</td></tr>";
            log = string.Format(logFormat, log);

            var dto = new TEntity
            {
                WebCrmId = id,
                Log = log,
                OrganisationId = organisationId
            };

            Update(
                dto,
                new List<Expression<Func<TEntity, object>>>
                {
                    dto1 => dto1.Log
                });
        }

        public ReadDocumentDataResult ReadDocument(long documentId)
        {
            ReadDocumentDataResult retval = _connection.Proxy.ReadDocument(_connection.Ticket, documentId);

            if (retval.ErrorStatus.Code != 0)
            {
                throw new ApplicationException($"Error occurred updating {retval.ErrorStatus.Message}");
            }

            return retval;
        }

        public long? ResolveId(string name)
        {
            string trimmedName = name.Trim();

            TEntity result = GetByName(trimmedName);

            return result?.WebCrmId;
        }

        public void Update(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> columns)
        {
            WebCrmData mappedPairs = MapToWebCrmData(entity, columns);

            WriteToWebCrmResult retval = _connection.Proxy.WriteToWebcrmDirect(
                _connection.Ticket,
                Mapper.DataEntityType,
                entity.OrganisationId,
                entity.WebCrmId,
                mappedPairs);

            if (retval.ErrorStatus.Code != 0)
            {
                throw new ApplicationException($"Error occurred updating {retval.ErrorStatus.Message}");
            }
        }

        public void Update(TEntity entity)
        {
            WebCrmData mappedPairs = MapToWebCrmData(entity);

            WriteToWebCrmResult retval = _connection.Proxy.WriteToWebcrmDirect(
                _connection.Ticket,
                Mapper.DataEntityType,
                entity.OrganisationId,
                entity.WebCrmId,
                mappedPairs);

            if (retval.ErrorStatus.Code != 0)
            {
                throw new ApplicationException($"Error occurred updating {retval.ErrorStatus.Message}");
            }
        }

        protected static Dictionary<string, string> GetDictionary(
            RetrieveByQueryResultRow row,
            RetrieveByQueryResult results)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (var field in row.FieldValues.Select((x, i) => new { Index = i, Value = x }))
            {
                dictionary.Add(results.Fields[field.Index], field.Value);
            }

            return dictionary;
        }

        protected virtual TEntity MapResult(Dictionary<string, string> getDictionary)
        {
            var dto1 = new TEntity();

            Mapper.MapTo(getDictionary, dto1);

            return dto1;
        }

        protected virtual WebCrmData MapToWebCrmData(TEntity entity)
        {
            var data = new WebCrmData { Pairs = Mapper.GetAllPairs(entity).ToArray() };

            return data;
        }

        protected virtual WebCrmData MapToWebCrmData(
            TEntity entity,
            IEnumerable<Expression<Func<TEntity, object>>> columns)
        {
            var data = new WebCrmData();

            Mapper.MapFrom(entity, columns, data);

            return data;
        }

        protected IEnumerable<TEntity> Query(string fromClause, string whereClause, string selectFields)
        {
            RetrieveByQueryResult results = RetrieveByQueryResult(fromClause, whereClause, selectFields);

            if (results.Rows?.Any() != true)
            {
                yield break;
            }

            foreach (RetrieveByQueryResultRow row in results.Rows)
            {
                Dictionary<string, string> dictionary = GetDictionary(row, results);
                yield return MapResult(dictionary);
            }
        }

        protected IEnumerable<TEntity> QueryBy<T>(Expression<Func<TEntity, object>> property, T value)
        {
            string columnName = ReflectionHelpers.GetName(property);

            MappingDefinition<TEntity> mappingDefinition = Mapper.MappingDefinitions.First(
                c =>
                    ReflectionHelpers.GetName(c.Property) ==
                    columnName);

            string quote = value.IsNumericType() ? string.Empty : "'";

            string where = $"{mappingDefinition.WebCrmField} = {quote}{value}{quote}";

            return QueryAllFields(where);
        }

        protected IEnumerable<TEntity> QueryBySql(string from, string where)
        {
            string selectFields = SelectFields;
            return Query(Mapper.Table, where, selectFields);
        }

        protected RetrieveByQueryResult RetrieveByQueryResult(string from, string where, string selectFields)
        {
            RetrieveByQueryResult results = _connection.Proxy.RetrieveByQuery(
                _connection.Ticket,
                selectFields,
                from,
                where,
                string.Empty);

            if (results.ErrorStatus.Code > 0)
            {
                throw new Exception(results.ErrorStatus.Message);
            }

            return results;
        }

        private IEnumerable<TEntity> QueryAllFields(string where)
        {
            string selectFields = SelectFields;
            return Query(Mapper.Table, where, selectFields);
        }
    }
}