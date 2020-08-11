namespace MongoManagerApp
{
    public interface IGettable<T>
    {
        T GetAll();
        T GetAllAsync();
    }
}