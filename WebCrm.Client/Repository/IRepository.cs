using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Repository
{
    public interface IRepository<TDto>
        where TDto : Entity, IWebCrmQueryable
    {
        long Add(TDto entity, IEnumerable<Expression<Func<TDto, object>>> columns);

        long AddDocument(
            byte[] file,
            long organisationId,
            string description,
            string fileExtension,
            string fileName,
            string folder,
            long id);

        TDto GetById(long id);

        TDto GetByName(string name);

        IEnumerable<KeyValuePair> GetLookUp(Expression<Func<TDto, object>> column);

        void Log(long id, long organisationId, string log);

        long? ResolveId(string name);

        void Update(TDto entity, IEnumerable<Expression<Func<TDto, object>>> columns);
    }
}