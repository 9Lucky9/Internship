namespace ReviewAPI.Repository
{
    interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Create(T item);
        bool Update(T item);
        bool Remove(int id);
    }
}
