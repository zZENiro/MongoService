using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoManagerApp
{
    public interface IGettable<T>
    {
        T GetAll();
        T GetAllAsync();
    }

    public interface ICratable<T>
    {
        Task<T> CreateOneAsync();
        Task<T> CreateManyAsync();
        T CreateMany(params T[] values);
        T CreateOne(T value);
    }

    public abstract class MongoService<T> :
        IGettable<T>, ICratable<T>
        where T : class
    {
        protected IMongoDatabase _database;
        protected IMongoClient _client;
        protected IMongoCollection<T> _collection;
       
        public MongoService(IMongoSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _collection = _database.GetCollection<T>(settings.CollectionName);
        }

        public List<T> Get() =>
            _collection.Find(one => true).ToList();

        public T Create(T value)
        {
            _collection.InsertOne(value);
            return value;
        }
    }
}