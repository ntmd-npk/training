namespace Repository.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();
        int Create(T entity);
        void Delete(int id);
        void Update(int id, T entity);
    }
}
