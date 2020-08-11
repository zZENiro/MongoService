using System.Threading.Tasks;

namespace MongoManagerApp
{
    public interface ICratable<T>
    {
        Task<T> CreateOneAsync();
        Task<T> CreateManyAsync();
        T CreateMany(params T[] values);
        T CreateOne(T value);
    }
}