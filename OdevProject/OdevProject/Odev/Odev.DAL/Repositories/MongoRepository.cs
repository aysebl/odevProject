using MongoDB.Driver;
using Odev.Core.Responses;
using Odev.DAL.Interface;
using Odev.DAL.MongoDbSettings;
using Odev.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Odev.DAL.Repositories
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            //localimdeki url adresi mongonun
            var database = new MongoClient("mongodb://localhost:27017/").GetDatabase("frms");
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public RepositoryResponse<TDocument> InsertOne(TDocument document)
        {
            var response = new RepositoryResponse<TDocument> { };

            try
            {
                _collection.InsertOne(document);
                response.Result = document;
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public IAggregateFluent<TDocument> Aggregate(AggregateOptions options = null)
        {
            return _collection.Aggregate(options);
        }

        public RepositoryResponse<List<TDocument>> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            var response = new RepositoryResponse<List<TDocument>> { };

            try
            {
                response.Result = _collection.Find(filterExpression)
                    .ToList();
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public RepositoryResponse<TDocument> FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            var response = new RepositoryResponse<TDocument> { };

            try
            {
                response.Result = _collection.Find(filterExpression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public RepositoryResponse<TDocument> ReplaceOne(TDocument document)
        {
            var response = new RepositoryResponse<TDocument> { };
            try
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
                _collection.FindOneAndReplace(filter, document);
                response.Result = document;
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public RepositoryResponse DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            var response = new RepositoryResponse { };

            try
            {
                _collection.FindOneAndDelete(filterExpression);
            }
            catch (Exception ex)
            {
                response.Successed = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
