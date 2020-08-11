using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MongoManagerApp
{
    public abstract class MongoService<T> :
        IGettable<T>, ICreatable<T>
        where T : class
    {
        protected IMongoDatabase _database;
        protected IMongoClient _client;
        protected IMongoCollection<T> _collection;
        private MongoSettings _settings;

        public MongoService(MongoSettings settings)
        {
            _settings = settings;
            if (_settings is null) throw new Exception();

            _client = new MongoClient(_settings.ConnectionString);
            _database = _client.GetDatabase(_settings.DatabaseName);
            _collection = _database.GetCollection<T>(_settings.CollectionName);
        }

        public MongoSettings Settings { get => _settings; set => _settings = value; }

        public List<T> Get() =>
            _collection.Find(one => true).ToList();

        public T Create(T value)
        {
            _collection.InsertOne(value);
            return value;
        }

        public T GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateOneAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateManyAsync()
        {
            throw new NotImplementedException();
        }

        public T CreateMany(params T[] values)
        {
            throw new NotImplementedException();
        }

        public T CreateOne(T value)
        {
            throw new NotImplementedException();
        }
    }
}