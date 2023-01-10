using MongoDB.Driver;
using Odev.Core.Responses;
using Odev.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Odev.DAL.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        RepositoryResponse<TDocument> InsertOne(TDocument document);

        IAggregateFluent<TDocument> Aggregate(AggregateOptions options = null);

        RepositoryResponse<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

        RepositoryResponse<TDocument> FindOne(Expression<Func<TDocument, bool>> filterExpression);

        RepositoryResponse<TDocument> ReplaceOne(TDocument document);

        RepositoryResponse DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

    }
}
