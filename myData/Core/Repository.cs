using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace myData.Core
{
  

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly IMongoCollection<TEntity> collection;

        protected Repository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            collection = db.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }


        public TEntity Create(TEntity item)
        {
            collection.InsertOne(item);
            return item;
        }

       

        public IList<TEntity> Get()
        {
            return collection.Find(col => true).ToList();
        }

        public IList<TEntity> GetPagedList(int pageNumber, int pageLimit, Expression<Func<TEntity,object>> orderBy)
        {

            return collection.Find(col => true).SortByDescending(orderBy).Skip((pageNumber -1) * pageLimit).Limit(pageLimit).ToList();
        }
    }
}