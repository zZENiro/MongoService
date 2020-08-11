using System.Threading.Tasks;

namespace MongoManagerApp
{
    public interface ICreatable<T>
    {
        Task<T> CreateOneAsync();
        Task<T> CreateManyAsync();
        T CreateMany(params T[] values);
        T CreateOne(T value);
    }
}